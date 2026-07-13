using AtlasLMS.API.DTOs;

namespace AtlasLMS.API.Services
{
    public interface ICategoryService
    {
        Task<CategoryReadDto> CreateCategoryAsync(CategoryCreateDto dto);
        Task DeleteCategoryAsync(int ID);
        Task<IEnumerable<CategoryReadDto>> GetCategoriesAsync();
        Task<CategoryReadDto> GetCategoryAsync(int ID);
    }
}