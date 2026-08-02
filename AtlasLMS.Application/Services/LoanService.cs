using AtlasLMS.Application.Contracts;
using AtlasLMS.Data;
using AtlasLMS.Domain.Entities;
using AtlasLMS.Domain.Exceptions;
using AtlasLMS.Shared.DTOs.Create;
using AtlasLMS.Shared.DTOs.Detail;
using AtlasLMS.Shared.DTOs.Read;

using AutoMapper;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AtlasLMS.Application.Services;

public class LoanService : ILoanService
{
    private readonly IMapper _mapper;
    private readonly AtlasDbContext _context;
    private readonly UserManager<User> _userManager;

    public LoanService(IMapper mapper, AtlasDbContext context, UserManager<User> userManager)
    {
        _mapper = mapper;
        _context = context;
        _userManager = userManager;
    }

    public async Task<IEnumerable<LoanReadDto>> GetLoansAsync()
    {
        var loans = await _context.Loans.ToListAsync();
        return _mapper.Map<IEnumerable<LoanReadDto>>(loans);
    }

    public async Task<IEnumerable<LoanReadDto>> GetLoansByStatusAsync(ELoanStatus? status)
    {
        var query = _context.Loans.AsQueryable();

        var filteredLoans = query.Where(x => x.Status == status);
        var loans = await filteredLoans.ToListAsync();

        return _mapper.Map<IEnumerable<LoanReadDto>>(loans);
    }

    public async Task<IEnumerable<LoanReadDto>> GetLoansByUserAsync(string userID)
    {
        var userExists = await _userManager.Users.AnyAsync(x => x.Id.Equals(userID));
        if (!userExists)
            throw new NotFoundException($"El usuario con ID {userID} no existe");

        var loans = await _context.Loans.Where(x => x.UserID.Equals(userID)).ToListAsync();
        return _mapper.Map<IEnumerable<LoanReadDto>>(loans);
    }

    public async Task<LoanReadDto> GetLoanAsync(int ID)
    {
        var loan = await _context.Loans.FirstOrDefaultAsync(x => x.ID == ID)
            ?? throw new NotFoundException($"El prestamo con ID {ID} no existe");
        return _mapper.Map<LoanReadDto>(loan);
    }

    public async Task<IEnumerable<LoanReadDto>> GetLoansByDueDateAsync(DateTime? limitDueDate)
    {
        var query = _context.Loans.AsQueryable();

        if (!limitDueDate.HasValue)
            throw new BadRequestException("Fecha no proporcionada");

        var filteredLoans = query.Where(x => x.DueDate <= limitDueDate.Value);

        var loans = await filteredLoans.ToListAsync();
        return _mapper.Map<IEnumerable<LoanReadDto>>(loans);
    }

    public async Task<LoanReadDto> GetLoanByBookAsync(int bookID)
    {
        var bookExists = await _context.Books.AnyAsync(x => x.ID == bookID);
        if (!bookExists)
            throw new NotFoundException($"El libro con ID {bookID} no existe");

        var loan = await _context.Loans.FirstOrDefaultAsync(x => x.BookID == bookID)
            ?? throw new NotFoundException($"No se han encontrado prestamos por el libro indicado");
        return _mapper.Map<LoanReadDto>(loan);
    }

    public async Task<LoanDetailDto> GetLoanDetailAsync(int ID)
    {
        var loan = await _context.Loans.Include(x => x.User).Include(x => x.Book).FirstOrDefaultAsync(x => x.ID == ID)
            ?? throw new NotFoundException($"Prestamo con ID {ID} no encontrado");
        return _mapper.Map<LoanDetailDto>(loan);
    }

    public async Task<LoanReadDto> CreateLoanAsync(LoanCreateDto dto)
    {
        var book = await _context.Books.FirstOrDefaultAsync(x => x.ID == dto.BookID)
            ?? throw new NotFoundException($"El libro con ID {dto.BookID} no existe");

        var userExists = await _userManager.Users.AnyAsync(x => x.Id.Equals(dto.UserID));
        if (!userExists)
            throw new NotFoundException($"El usuario {dto.UserID} no existe");

        //Si el usuario ha superado el limite de prestamos(3), lanzamos badrequest
        //Filtramos por userID y estado de prestamo(activo)
        var totalUserLoans = await _context.Loans.CountAsync(x => x.UserID == dto.UserID && x.Status == ELoanStatus.Active);
        if (totalUserLoans >= 3)
            throw new BadRequestException($"Lo sentimos. El usuario {dto.UserID} ha superado el limite de prestamos activos");

        //Si la suma de prestamos y reservas activas da el total de stock del libro, lanzamos badrequest
        var activeLoans = await _context.Loans.CountAsync(x => x.BookID == dto.BookID && x.DueDate > DateTime.UtcNow);
        var activeBookings = await _context.Bookings.CountAsync(x => x.BookID == dto.BookID && x.PickupDeadline > DateTime.UtcNow);
        if ((activeBookings + activeLoans) >= book.Stock)
            throw new BadRequestException($"No hay ejemplares para el libro {dto.BookID}");

        //Si el usuario ya consta de un prestamo con el mismo libro y la fecha final es mayor a la de comienzo, lanzamos badrequest
        var loansUserWithBook = await _context.Loans
            .AnyAsync(x => x.BookID == dto.BookID && x.UserID == dto.UserID && x.DueDate > DateTime.UtcNow && x.Status == ELoanStatus.Active);
        if (loansUserWithBook)
            throw new BadRequestException($"El libro {dto.BookID} ya esta siendo prestado al mismo usuario {dto.UserID}");

        //Si el tiempo de vida del prestamo es menor a 7 o mayor a 30, lanzamos badrequest
        if (dto.LifeTime < 7 || dto.LifeTime > 30)
            throw new BadRequestException($"La duracion no puede ser menor a 7 dias, tampoco mayor a 30 dias");

        var loan = _mapper.Map<Loan>(dto);

        //Fecha de comienzo del prestamo(actual)
        loan.StartDate = DateTime.UtcNow;
        //Fecha limite => fecha de comienzo le agregamos los dias del tiempo de vida del prestamo
        loan.DueDate = loan.StartDate.AddDays(loan.LifeTime);

        _context.Add(loan);
        await _context.SaveChangesAsync();
        return _mapper.Map<LoanReadDto>(loan);

    }

    public async Task DeleteLoanAsync(int ID)
    {
        var loan = await _context.Loans.FirstOrDefaultAsync(x => x.ID == ID)
            ?? throw new NotFoundException($"El prestamo con ID {ID} no existe");

        var loanHasAnyBook = await _context.Loans.AnyAsync(x => x.BookID == loan.BookID && x.Status == ELoanStatus.Active);
        if (loanHasAnyBook)
            throw new BadRequestException($"El libro esta siendo prestado a un usuario. El prestamo se encuentra de forma activa");

        _context.Remove(loan);
        await _context.SaveChangesAsync();
    }
}
