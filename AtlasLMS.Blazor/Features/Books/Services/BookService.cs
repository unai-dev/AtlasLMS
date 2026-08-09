using System.Net.Http.Json;

using AtlasLMS.Blazor.Features.Books.Contracts;
using AtlasLMS.Shared.DTOs.Create;
using AtlasLMS.Shared.DTOs.Detail;
using AtlasLMS.Shared.DTOs.Read;
using AtlasLMS.Shared.DTOs.Update;

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

    public async Task<BookReadDto?> GetBookAsync(int ID) =>
        await _http.GetFromJsonAsync<BookReadDto>($"books/{ID}");

    public async Task<BookDetailDto?> GetBookDetailAsync(int ID) =>
        await _http.GetFromJsonAsync<BookDetailDto>($"books/detail/{ID}");

    public async Task<HttpResponseMessage> CreateBookAsync(BookCreateDto dto) =>
        await _http.PostAsJsonAsync("books", dto);

    public async Task<HttpResponseMessage> UpdateBookAsync(int ID, BookUpdateDto dto) =>
        await _http.PutAsJsonAsync($"books/{ID}", dto);

    public async Task<HttpResponseMessage> DeleteBookAsync(int ID) =>
        await _http.DeleteAsync($"books/{ID}");
}
