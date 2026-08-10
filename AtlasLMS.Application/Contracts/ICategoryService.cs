using AtlasLMS.Shared.DTOs.Create;
using AtlasLMS.Shared.DTOs.Read;

namespace AtlasLMS.Application.Contracts;

public interface ICategoryService
{
    Task<CategoryReadDto> CreateCategoryAsync(CategoryCreateDto dto);
    Task DeleteCategoryAsync(int ID);
    Task<IEnumerable<CategoryReadDto>> GetCategoriesAsync();
    Task<CategoryReadDto> GetCategoryAsync(int ID);
}
