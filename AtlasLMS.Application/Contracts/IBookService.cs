using AtlasLMS.Shared.DTOs.Create;
using AtlasLMS.Shared.DTOs.Detail;
using AtlasLMS.Shared.DTOs.Read;
using AtlasLMS.Shared.DTOs.Update;

namespace AtlasLMS.Application.Contracts
{
    public interface IBookService
    {
        Task<BookReadDto> CreateBookAsync(BookCreateDto dto);
        Task<BookReadDto> UpdateBookAsync(int ID, BookUpdateDto dto);
        Task DeleteBookAsync(int ID);
        Task<BookReadDto> GetBook(int ID);
        Task<BookDetailDto> GetBookDetailAsync(int ID);
        Task<IEnumerable<BookReadDto>> GetBooksAsync();
    }
}