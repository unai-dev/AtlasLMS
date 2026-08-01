using AtlasLMS.Shared.DTOs.Create;
using AtlasLMS.Shared.DTOs.Read;

namespace AtlasLMS.Blazor.Features.Categories.Contracts
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryReadDto>> GetCategoriesAsync();
        Task<CategoryReadDto?> CreateCategoryAsync(CategoryCreateDto dto);
        Task<HttpResponseMessage> DeleteCategoryAsync(int ID);
    }
}