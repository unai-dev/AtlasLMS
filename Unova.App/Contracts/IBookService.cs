using Unova.App.Contracts.Common;

namespace Unova.App.Contracts;

public interface IBookService : IUnovaContract<BookReadDto, BookDetailDto, BookCreateDto>
{
}
