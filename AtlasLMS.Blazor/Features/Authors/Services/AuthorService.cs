using System.Net.Http.Json;

using AtlasLMS.Blazor.Features.Authors.Contracts;
using AtlasLMS.Shared.DTOs.Create;
using AtlasLMS.Shared.DTOs.Read;

namespace AtlasLMS.Blazor.Features.Authors.Services;

public class AuthorService : IAuthorService
{
    private readonly HttpClient _http;

    public AuthorService(HttpClient http)
    {
        _http = http;
    }

    public async Task<IEnumerable<AuthorReadDto>> GetAuthorsAsync() =>
        await _http.GetFromJsonAsync<IEnumerable<AuthorReadDto>>("authors") ?? [];

    public async Task<HttpResponseMessage> CreateAuthorAsync(AuthorCreateDto dto) =>
        await _http.PostAsJsonAsync("authors", dto);

    public async Task<HttpResponseMessage> DeleteAuthorAsync(int ID) =>
        await _http.DeleteAsync($"authors/{ID}");
}
