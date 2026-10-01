using AutoMapper;

using Microsoft.EntityFrameworkCore;

using Unova.App.Contracts;
using Unova.Domain.Entities;
using Unova.Infrastructure;
using Unova.Shared.DTOs.Create;
using Unova.Shared.DTOs.Detail;
using Unova.Shared.DTOs.Read;
using Unova.Shared.DTOs.Update;

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

    public async Task<AuthorReadDto> UpdateAuthorAsync(int ID, AuthorUpdateDto dto)
    {
        var author = await _context.Authors.FirstOrDefaultAsync(x => x.ID == ID)
            ?? throw new NotFoundException($"El autor con ID {ID} no existe");

        //Validamos que el usuario con el mismo nombre no exista
        if (!string.IsNullOrEmpty(dto.FirstName) && !string.IsNullOrEmpty(dto.LastName))
        {
            var authorWithNameExists = await _context.Authors
                .AnyAsync(x => x.FirstName.Equals(dto.FirstName) && x.LastName.Equals(dto.LastName));
            if (authorWithNameExists)
                throw new BadRequestException($"El autor {dto.FirstName} {dto.LastName} ya existe");
        }

        //Si el DTO no tiene la informacion, guardamos el valor anterior
        author.FirstName = dto.FirstName ?? author.FirstName;
        author.LastName = dto.LastName ?? author.LastName;
        author.UpdatedAt = DateTime.UtcNow;

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
