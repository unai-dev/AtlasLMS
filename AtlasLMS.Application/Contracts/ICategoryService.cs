using AtlasLMS.Application.Contracts.Common;
using AtlasLMS.Shared.DTOs.Create;
using AtlasLMS.Shared.DTOs.Read;

namespace AtlasLMS.Application.Contracts;

public interface ICategoryService
{
    Task<IEnumerable<CategoryReadDto>> GetCategoriesAsync();
    Task<CategoryReadDto> GetCategoryAsync(int ID);
    Task<CategoryReadDto> CreateCategoryAsync(CategoryCreateDto dto);
    Task DeleteCategoryAsync(int ID);
}
