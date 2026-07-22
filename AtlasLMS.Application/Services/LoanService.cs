using AtlasLMS.Application.Contracts;
using AtlasLMS.Data;
using AtlasLMS.Domain.Entities;
using AtlasLMS.Domain.Exceptions;
using AtlasLMS.Shared.DTOs.Create;
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

    public async Task<LoanReadDto> CreateLoanAsync(LoanCreateDto dto)
    {
        var bookExists = await _context.Books.AnyAsync(x => x.ID == dto.BookID);
        if (!bookExists)
            throw new NotFoundException($"El libro con ID {dto.BookID} no existe");

        var isOnLoan = await _context.Loans.AnyAsync(x => x.BookID == dto.BookID && x.DueDate > DateTime.UtcNow);
        if (isOnLoan)
            throw new BadRequestException($"El libro con ID {dto.BookID} ya esta siendo prestado a otro usuario");

        var isBooking = await _context.Bookings.AnyAsync(x => x.BookID == dto.BookID && x.PickupDeadline > DateTime.UtcNow);
        if (isBooking)
            throw new BadRequestException($"El libro {dto.BookID} esta reservado por un usuario");

        var userExists = await _userManager.Users.AnyAsync(x => x.Id.Equals(dto.UserID));
        if (!userExists)
            throw new NotFoundException($"El usuario {dto.UserID} no existe");

        var loan = _mapper.Map<Loan>(dto);
        loan.StartDate = DateTime.UtcNow;
        loan.DueDate = loan.StartDate.AddDays(loan.LifeTime);
        _context.Add(loan);
        await _context.SaveChangesAsync();
        return _mapper.Map<LoanReadDto>(loan);

    }

    public async Task DeleteLoanAsync(int ID)
    {
        var loan = await _context.Loans.FirstOrDefaultAsync(x => x.ID == ID)
            ?? throw new NotFoundException($"El prestamo con ID {ID} no existe");
        _context.Remove(loan);
        await _context.SaveChangesAsync();
    }
}
