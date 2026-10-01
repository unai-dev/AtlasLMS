using Unova.App.Contracts.Common;
using Unova.Shared.DTOs.Update;

namespace Unova.App.Contracts;

public interface IBookService : IUnovaContract<BookReadDto, BookDetailDto, BookCreateDto>
{
    Task<BookReadDto> UpdateBookAsync(int ID, BookUpdateDto dto);
}