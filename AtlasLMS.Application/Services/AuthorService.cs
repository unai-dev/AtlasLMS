using AtlasLMS.Application.Contracts;
using AtlasLMS.Data;
using AtlasLMS.Domain.Entities;
using AtlasLMS.Domain.Exceptions;
using AtlasLMS.Shared.DTOs.Create;
using AtlasLMS.Shared.DTOs.Detail;
using AtlasLMS.Shared.DTOs.Read;
using AtlasLMS.Shared.DTOs.Update;
using AtlasLMS.Tools;

using AutoMapper;

using Microsoft.EntityFrameworkCore;

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
        var author = await _context.Authors
            .Include(x => x.Books)
            .FirstOrDefaultAsync(x => x.ID == ID)
            ?? throw new NotFoundException($"Autor con ID {ID} no encontrado");
        return _mapper.Map<AuthorDetailDto>(author);
    }

    public async Task<AuthorReadDto> CreateAuthorAsync(AuthorCreateDto dto)
    {
        var authorExists = await _context.Authors
            .AnyAsync(x => AtlasHelper.IsEqualsStr(x.FirstName, dto.FirstName) && AtlasHelper.IsEqualsStr(x.LastName, dto.LastName));
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

        if (AtlasHelper.AreNotStringsEmpty(dto.FirstName, dto.LastName))
        {
            var authorWithNameExists = await _context.Authors
                .AnyAsync(x => AtlasHelper.IsEqualsStr(x.FirstName, dto.FirstName) && AtlasHelper.IsEqualsStr(x.LastName, dto.LastName));
            if (authorWithNameExists)
                throw new BadRequestException($"El autor {dto.FirstName} {dto.LastName} ya existe");
        }

        author.FirstName = AtlasHelper.GetOrFallbackStr(dto.FirstName, author.FirstName);
        author.LastName = AtlasHelper.GetOrFallbackStr(dto.LastName, author.LastName);
        author.UpdatedAt = DateTime.UtcNow;

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
