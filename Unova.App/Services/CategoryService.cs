using AutoMapper;

using Microsoft.EntityFrameworkCore;

using Unova.App.Contracts;
using Unova.Domain.Entities;
using Unova.Infrastructure;
using Unova.Shared.DTOs.Create;
using Unova.Shared.DTOs.Detail;
using Unova.Shared.DTOs.Read;

namespace Unova.App.Services;

public class CategoryService : ICategoryService
{
    private readonly IMapper _mapper;
    private readonly UnovaDbContext _context;

    public CategoryService(IMapper mapper, UnovaDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<IEnumerable<CategoryReadDto>> GetAll()
    {
        var categories = await _context.Categories
            .AsNoTracking()
            .ToListAsync();
        return _mapper.Map<IEnumerable<CategoryReadDto>>(categories);
    }

    public async Task<CategoryReadDto> GetByID(int ID)
    {
        var category = await _context.Categories
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.ID == ID) ??
            throw new NotFoundException("Categoria no econtrada");
        return _mapper.Map<CategoryReadDto>(category);
    }

    public async Task<CategoryDetailDto> GetDetail(int ID)
    {
        var category = await _context.Categories
            .Include(x => x.Books)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.ID == ID) ??
            throw new NotFoundException("Categoria no econtrada");
        return _mapper.Map<CategoryDetailDto>(category);
    }

    public async Task<CategoryReadDto> Create(CategoryCreateDto dto)
    {
        var categoryExists = await _context.Categories.AnyAsync(x => x.Name.Equals(dto.Name));
        if (categoryExists)
            throw new BadRequestException($"La categoria {dto.Name} ya existe");

        var category = _mapper.Map<Category>(dto);

        _context.Add(category);
        await _context.SaveChangesAsync();

        return _mapper.Map<CategoryReadDto>(category);
    }

    public async Task Delete(int ID)
    {
        var category = await _context.Categories.FirstOrDefaultAsync(x => x.ID == ID) ??
            throw new NotFoundException("Categoria no encontrada");

        var categoryHasAnyBook = await _context.Books.AnyAsync(x => x.CategoryID == ID);
        if (categoryHasAnyBook)
            throw new BadRequestException($"La categoria no puede ser eliminada. Esta relacionada con algun libro");

        _context.Remove(category);
        await _context.SaveChangesAsync();
    }
}
