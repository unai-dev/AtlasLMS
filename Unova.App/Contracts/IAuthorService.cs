using Unova.App.Contracts.Common;
using Unova.Shared.DTOs.Update;

namespace Unova.App.Contracts;

public interface IAuthorService : IUnovaContract<AuthorReadDto, AuthorDetailDto, AuthorCreateDto>
{
    Task<AuthorReadDto> UpdateAuthorAsync(int ID, AuthorUpdateDto dto);
}
