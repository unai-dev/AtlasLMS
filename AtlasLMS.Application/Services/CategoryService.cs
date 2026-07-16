using AtlasLMS.Data;
using AtlasLMS.Application.DTOs.Create;
using AtlasLMS.Application.DTOs.Read;
using AtlasLMS.Domain.Entities;
using AtlasLMS.Domain.Exceptions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using AtlasLMS.Application.Contracts;

namespace AtlasLMS.Application.Services;

public class CategoryService : ICategoryService
{
    private readonly IMapper _mapper;
    private readonly AtlasDbContext _context;

    public CategoryService(IMapper mapper, AtlasDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<IEnumerable<CategoryReadDto>> GetCategoriesAsync()
    {
        var categories = await _context.Categories.ToListAsync() ?? [];
        return _mapper.Map<IEnumerable<CategoryReadDto>>(categories);
    }

    public async Task<CategoryReadDto> GetCategoryAsync(int ID)
    {
        var category = await _context.Categories.FirstOrDefaultAsync(x => x.ID == ID) ??
            throw new NotFoundException("Categoria no econtrada");
        return _mapper.Map<CategoryReadDto>(category);
    }

    public async Task<CategoryReadDto> CreateCategoryAsync(CategoryCreateDto dto)
    {
        var exists = await _context.Categories.AnyAsync(x => x.Name == dto.Name);
        if (exists)
        {
            throw new BadRequestException($"La categoria {dto.Name} ya existe");
        }
        var category = _mapper.Map<Category>(dto);

        _context.Add(category);
        await _context.SaveChangesAsync();

        return _mapper.Map<CategoryReadDto>(category);
    }

    public async Task DeleteCategoryAsync(int ID)
    {
        var category = await _context.Categories.FirstOrDefaultAsync(x => x.ID == ID) ??
            throw new NotFoundException("Categoria no encontrada");
        _context.Remove(category);
        await _context.SaveChangesAsync();
    }
}
