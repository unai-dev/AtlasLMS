using AtlasLMS.API.Config;
using AtlasLMS.API.DTOs;
using AtlasLMS.API.Entities;
using AtlasLMS.API.Utils.Exceptions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AtlasLMS.API.Services;

public class AuthorService : IAuthorService
{
    private readonly ILogger<AuthorService> _logger;
    private readonly IMapper _mapper;
    private readonly AtlasDbContext _context;

    public AuthorService(ILogger<AuthorService> logger, IMapper mapper, AtlasDbContext context)
    {
        _logger = logger;
        _mapper = mapper;
        _context = context;
    }


    public async Task<IEnumerable<AuthorReadDto>> GetAuthorsAsync()
    {
        try
        {
            var authors = await _context.Authors.ToListAsync();
            return _mapper.Map<IEnumerable<AuthorReadDto>>(authors);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);
            throw new InternalServerException($"Error interno del servidor {ex.Message}");
        }
    }

    public async Task<AuthorReadDto> GetAuthorAsync(int ID)
    {
        try
        {
            var author = await _context.Authors.FirstOrDefaultAsync(x => x.ID == ID) ??
                throw new NotFoundException("Autor no encontrado");
            return _mapper.Map<AuthorReadDto>(author);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);
            throw new InternalServerException($"Error interno del servidor {ex.Message}");
        }
    }

    public async Task<AuthorDetailDto> GetAuthorDetailAsync(int ID)
    {
        try
        {
            var author = await _context.Authors.Include(x => x.Books)
                .FirstOrDefaultAsync(x => x.ID == ID) ??
                throw new NotFoundException($"Autor con ID {ID} no encontrado");

            return _mapper.Map<AuthorDetailDto>(author);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);
            throw new InternalServerException($"Error interno del servidor {ex.Message}");
        }
    }

    public async Task<AuthorReadDto> CreateAuthorAsync(AuthorCreateDto dto)
    {
        var exists = await _context.Authors.AnyAsync(x => x.FirstName == dto.FirstName && x.LastName == dto.LastName);
        if (exists)
        {
            throw new BadRequestException($"El autor {dto.FirstName.Concat(dto.LastName)} ya existe");
        }
        try
        {
            var author = _mapper.Map<Author>(dto);
            _context.Add(author);
            await _context.SaveChangesAsync();

            return _mapper.Map<AuthorReadDto>(author);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);
            throw new InternalServerException($"Error interno del servidor {ex.Message}");
        }
    }

    public async Task DeleteAuthorAsync(int ID)
    {
        try
        {
            var author = await _context.Authors.FirstOrDefaultAsync(x => x.ID == ID) ??
                throw new NotFoundException("Autor no encontrado");

            _context.Remove(author);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);
            throw new InternalServerException($"Error interno del servidor {ex.Message}");
        }
    }

}
