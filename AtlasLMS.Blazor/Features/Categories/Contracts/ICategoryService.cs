using AtlasLMS.Shared.DTOs.Read;

namespace AtlasLMS.Blazor.Features.Categories.Contracts
{
    public interface ICategoryService
    {
        Task<HttpResponseMessage> DeleteCategoryAsync(int ID);
        Task<IEnumerable<CategoryReadDto>> GetCategoriesAsync();
    }
}