using AtlasLMS.Shared.DTOs.Read;

namespace AtlasLMS.Blazor.Features.Books.Contracts
{
    public interface IBookService
    {
        Task<HttpResponseMessage> DeleteBookAsync(int ID);
        Task<IEnumerable<BookReadDto>> GetBooksAsync();
    }
}