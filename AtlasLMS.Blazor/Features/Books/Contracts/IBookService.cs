using AtlasLMS.Shared.DTOs.Create;
using AtlasLMS.Shared.DTOs.Detail;
using AtlasLMS.Shared.DTOs.Read;
using AtlasLMS.Shared.DTOs.Update;

namespace AtlasLMS.Blazor.Features.Books.Contracts;

public interface IBookService
{
    Task<IEnumerable<BookReadDto>> GetBooksAsync();
    Task<BookReadDto?> GetBookAsync(int ID);
    Task<BookDetailDto?> GetBookDetailAsync(int ID);
    Task<HttpResponseMessage> CreateBookAsync(BookCreateDto dto);
    Task<HttpResponseMessage> UpdateBookAsync(int ID, BookUpdateDto dto);
    Task<HttpResponseMessage> DeleteBookAsync(int ID);
}