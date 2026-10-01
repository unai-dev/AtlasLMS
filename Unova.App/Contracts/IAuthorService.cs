using AtlasLMS.Application.Contracts.Common;
using AtlasLMS.Shared.DTOs.Create;
using AtlasLMS.Shared.DTOs.Detail;
using AtlasLMS.Shared.DTOs.Read;
using AtlasLMS.Shared.DTOs.Update;

namespace AtlasLMS.Application.Contracts;

public interface IAuthorService : IAtlasContract<AuthorReadDto, AuthorDetailDto, AuthorCreateDto>
{
    Task<AuthorReadDto> UpdateAuthorAsync(int ID, AuthorUpdateDto dto);
}
