using AtlasLMS.Application.DTOs.Read;
using AtlasLMS.Data;
using AtlasLMS.Data.Entities;
using AtlasLMS.Domain.Exceptions;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AtlasLMS.Application.Services;

public class LoanService
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

    //Obtener todos los prestamos
    public async Task<IEnumerable<LoanReadDto>> GetLoansAsync()
    {
        var loans = await _context.Loans.ToListAsync();
        return _mapper.Map<IEnumerable<LoanReadDto>>(loans);
    }
    //Obtener prestamos del usuario
    public async Task<IEnumerable<LoanReadDto>> GetLoansByUserAsync(string userID)
    {
        var userExists = await _userManager.Users.AnyAsync(x => x.Id == userID);
        if (!userExists)
            throw new NotFoundException($"El usuario con el ID {userID} no existe");

        var loans = await _context.Loans.Where(x => x.UserID == userID).ToListAsync();
        return _mapper.Map<IEnumerable<LoanReadDto>>(loans);
    }
    //Obtener prestamo en concreto por ID
    public async Task<LoanReadDto> GetLoanAsync(int ID)
    {
        var loan = await _context.Loans.FirstOrDefaultAsync(x => x.ID == ID)
            ?? throw new NotFoundException($"El prestamo con el ID {ID} no existe");
        return _mapper.Map<LoanReadDto>(loan);
    }
    //Obtener prestamos menor a la fecha limite
    public async Task<IEnumerable<LoanReadDto>> GetLoansByDueDateAsync(DateTime? limitDueDate)
    {
        var query = _context.Loans.AsQueryable();

        if (!limitDueDate.HasValue)
            throw new BadRequestException("Fecha no proporcionada");

        var filteredLoans = query.Where(x => x.DueDate <= limitDueDate.Value);

        var loans = await filteredLoans.ToListAsync();
        return _mapper.Map<IEnumerable<LoanReadDto>>(loans);
    }
    //Obtener prestamo por libro
    public async Task<LoanReadDto> GetLoanByBookAsync(int bookID)
    {
        var bookExists = await _context.Books.AnyAsync(x => x.ID == bookID);

        if (!bookExists)
            throw new NotFoundException($"El libro con el ID {bookID} no existe");

        var loan = await _context.Loans.Where(x => x.BookID == bookID).FirstOrDefaultAsync()
            ?? throw new NotFoundException($"No se han encontrado prestamos por el libro indicado");
        return _mapper.Map<LoanReadDto>(loan);
    }

    //Crear prestamo

    //Actualizar prestamo

    //Eliminar prestamo
}
