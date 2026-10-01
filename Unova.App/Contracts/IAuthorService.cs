using Unova.App.Contracts.Common;
using Unova.Shared.DTOs.Create;
using Unova.Shared.DTOs.Detail;
using Unova.Shared.DTOs.Read;
using Unova.Shared.DTOs.Update;

namespace Unova.App.Contracts;

public interface IAuthorService : IAtlasContract<AuthorReadDto, AuthorDetailDto, AuthorCreateDto>
{
    Task<AuthorReadDto> UpdateAuthorAsync(int ID, AuthorUpdateDto dto);
}
