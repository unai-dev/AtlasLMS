using AtlasLMS.Data;
using AtlasLMS.Application.DTOs.Create;
using AtlasLMS.Application.DTOs.Detail;
using AtlasLMS.Application.DTOs.Read;
using AtlasLMS.Domain.Exceptions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using AtlasLMS.Application.Contracts;
using AtlasLMS.Domain.Entities;

namespace AtlasLMS.Application.Services;

public class AuthorService : IAuthorService
{
    private readonly IMapper _mapper;
    private readonly AtlasDbContext _context;

    public AuthorService(IMapper mapper, AtlasDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }


    public async Task<IEnumerable<AuthorReadDto>> GetAuthorsAsync()
    {
        var authors = await _context.Authors.ToListAsync();
        return _mapper.Map<IEnumerable<AuthorReadDto>>(authors);
    }

    public async Task<AuthorReadDto> GetAuthorAsync(int ID)
    {
        var author = await _context.Authors.FirstOrDefaultAsync(x => x.ID == ID) ??
            throw new NotFoundException($"Autor con ID {ID} no encontrado");
        return _mapper.Map<AuthorReadDto>(author);
    }

    public async Task<AuthorDetailDto> GetAuthorDetailAsync(int ID)
    {
        var author = await _context.Authors.Include(x => x.Books)
            .FirstOrDefaultAsync(x => x.ID == ID)
            ?? throw new NotFoundException($"Autor con ID {ID} no encontrado");
        return _mapper.Map<AuthorDetailDto>(author);
    }

    public async Task<AuthorReadDto> CreateAuthorAsync(AuthorCreateDto dto)
    {
        var exists = await _context.Authors.AnyAsync(x => x.FirstName == dto.FirstName && x.LastName == dto.LastName);
        if (exists)
            throw new BadRequestException($"El autor {dto.FirstName + " " + dto.LastName} ya existe");

        var author = _mapper.Map<Author>(dto);
        _context.Add(author);
        await _context.SaveChangesAsync();

        return _mapper.Map<AuthorReadDto>(author);
    }


    public async Task DeleteAuthorAsync(int ID)
    {
        var author = await _context.Authors.FirstOrDefaultAsync(x => x.ID == ID) ??
            throw new NotFoundException($"Autor con ID {ID} no encontrado");

        _context.Remove(author);
        await _context.SaveChangesAsync();
    }
}
