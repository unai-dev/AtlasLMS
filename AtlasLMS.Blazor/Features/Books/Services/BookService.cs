using System.Net.Http.Json;

using AtlasLMS.Blazor.Features.Books.Contracts;
using AtlasLMS.Shared.DTOs.Create;
using AtlasLMS.Shared.DTOs.Read;

namespace AtlasLMS.Blazor.Features.Books.Services;

public class BookService : IBookService
{
    private readonly HttpClient _http;

    public BookService(HttpClient http)
    {
        _http = http;
    }

    public async Task<IEnumerable<BookReadDto>> GetBooksAsync() =>
        await _http.GetFromJsonAsync<IEnumerable<BookReadDto>>("books") ?? [];

    public async Task<HttpResponseMessage> CreateBookAsync(BookCreateDto dto) =>
        await _http.PostAsJsonAsync("books", dto);

    public async Task<HttpResponseMessage> DeleteBookAsync(int ID) =>
        await _http.DeleteAsync($"books/{ID}");
}
