using AtlasLMS.API.Config;
using AtlasLMS.API.DTOs;
using AtlasLMS.API.Entities;
using AtlasLMS.API.Utils.Exceptions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AtlasLMS.API.Services;

public class CategoryService : ICategoryService
{
    private readonly ILogger<CategoryService> _logger;
    private readonly IMapper _mapper;
    private readonly AtlasDbContext _context;

    public CategoryService(ILogger<CategoryService> logger, IMapper mapper, AtlasDbContext context)
    {
        _logger = logger;
        _mapper = mapper;
        _context = context;
    }

    public async Task<IEnumerable<CategoryReadDto>> GetCategoriesAsync()
    {
        try
        {
            var categories = await _context.Categories.ToListAsync() ?? [];

            return _mapper.Map<IEnumerable<CategoryReadDto>>(categories);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);
            throw new InternalServerException($"Error interno del servidor {ex.Message}");
        }
    }

    public async Task<CategoryReadDto> GetCategoryAsync(int ID)
    {
        try
        {
            var category = await _context.Categories.FirstOrDefaultAsync(x => x.ID == ID) ??
                throw new NotFoundException("Categoria no econtrada");
            return _mapper.Map<CategoryReadDto>(category);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);
            throw new InternalServerException($"Error interno del servidor {ex.Message}");
        }

    }

    public async Task<CategoryReadDto> CreateCategoryAsync(CategoryCreateDto dto)
    {
        var exists = await _context.Categories.AnyAsync(x => x.Name == dto.Name);
        if (exists)
        {
            throw new BadRequestException($"La categoria {dto.Name} ya existe");
        }

        try
        {
            var category = _mapper.Map<Category>(dto);

            _context.Add(category);
            await _context.SaveChangesAsync();

            return _mapper.Map<CategoryReadDto>(category);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);
            throw new InternalServerException($"Error interno del servidor {ex.Message}");
        }
    }

    public async Task DeleteCategoryAsync(int ID)
    {
        try
        {
            var category = await _context.Categories.FirstOrDefaultAsync(x => x.ID == ID) ??
                throw new NotFoundException("Categoria no encontrada");
            _context.Remove(category);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);
            throw new InternalServerException($"Error interno del servidor {ex.Message}");
        }
    }
}
