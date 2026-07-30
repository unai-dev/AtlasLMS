using System.Net.Http.Json;

using AtlasLMS.Blazor.Features.Categories.Contracts;
using AtlasLMS.Shared.DTOs.Read;

namespace AtlasLMS.Blazor.Features.Categories.Services;

public class CategoryService : ICategoryService
{
    private readonly HttpClient _http;

    public CategoryService(HttpClient http)
    {
        _http = http;
    }

    public async Task<IEnumerable<CategoryReadDto>> GetCategoriesAsync() =>
        await _http.GetFromJsonAsync<IEnumerable<CategoryReadDto>>("categories") ?? [];

    public async Task<HttpResponseMessage> DeleteCategoryAsync(int ID) =>
        await _http.DeleteAsync($"categories/{ID}");
}
