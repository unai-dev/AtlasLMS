using AtlasLMS.Shared.DTOs.Create;
using AtlasLMS.Shared.DTOs.Read;

namespace AtlasLMS.Blazor.Features.Books.Contracts
{
    public interface IBookService
    {
        Task<IEnumerable<BookReadDto>> GetBooksAsync();
        Task<HttpResponseMessage> CreateBookAsync(BookCreateDto dto);
        Task<HttpResponseMessage> DeleteBookAsync(int ID);
    }
}