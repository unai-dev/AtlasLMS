using AtlasLMS.Shared.DTOs.Create;
using AtlasLMS.Shared.DTOs.Detail;
using AtlasLMS.Shared.DTOs.Read;

namespace AtlasLMS.Application.Contracts;

public interface IAuthorService
{
    Task<AuthorReadDto> CreateAuthorAsync(AuthorCreateDto dto);
    Task DeleteAuthorAsync(int ID);
    Task<AuthorReadDto> GetAuthorAsync(int ID);
    Task<AuthorDetailDto> GetAuthorDetailAsync(int ID);
    Task<IEnumerable<AuthorReadDto>> GetAuthorsAsync();
}
