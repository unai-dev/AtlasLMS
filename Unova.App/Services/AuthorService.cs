using AutoMapper;

using Microsoft.EntityFrameworkCore;

namespace Unova.App.Services;

public class AuthorService : IAuthorService
{
    private readonly IMapper _mapper;
    private readonly UnovaDbContext _context;

    public AuthorService(IMapper mapper, UnovaDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<IEnumerable<AuthorReadDto>> GetAll()
    {
        var authors = await _context.Authors
            .AsNoTracking()
            .ToListAsync();
        return _mapper.Map<IEnumerable<AuthorReadDto>>(authors);
    }

    public async Task<AuthorReadDto> GetByID(int ID)
    {
        var author = await _context.Authors
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.ID == ID) ??
            throw new NotFoundException($"Autor con ID {ID} no encontrado");
        return _mapper.Map<AuthorReadDto>(author);
    }

    public async Task<AuthorDetailDto> GetDetail(int ID)
    {
        var author = await _context.Authors
            .Include(x => x.Books)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.ID == ID)
            ?? throw new NotFoundException($"Autor con ID {ID} no encontrado");

        return _mapper.Map<AuthorDetailDto>(author);
    }

    public async Task<AuthorReadDto> Create(AuthorCreateDto dto)
    {
        //Validamos que el usuario con el mismo nombre no exista
        var authorExists = await _context.Authors
            .AnyAsync(x => x.FirstName.Equals(dto.FirstName) && x.LastName.Equals(dto.LastName));
        if (authorExists)
            throw new BadRequestException($"El autor {dto.FirstName} {dto.LastName} ya existe");

        var author = _mapper.Map<Author>(dto);
        _context.Add(author);
        await _context.SaveChangesAsync();

        return _mapper.Map<AuthorReadDto>(author);
    }

    public async Task Delete(int ID)
    {
        var author = await _context.Authors.FirstOrDefaultAsync(x => x.ID == ID) ??
            throw new NotFoundException($"Autor con ID {ID} no encontrado");

        var authorHaveAnyBook = await _context.Books.AnyAsync(x => x.AuthorID == ID);
        if (authorHaveAnyBook)
            throw new BadRequestException($"El autor no puede ser eliminado. Tiene libros asignados");

        _context.Remove(author);
        await _context.SaveChangesAsync();
    }
}
