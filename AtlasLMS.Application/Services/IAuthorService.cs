using AtlasLMS.Application.DTOs.Create;
using AtlasLMS.Application.DTOs.Detail;
using AtlasLMS.Application.DTOs.Read;

namespace AtlasLMS.Application.Services;

public interface IAuthorService
{
    Task<AuthorReadDto> CreateAuthorAsync(AuthorCreateDto dto);
    Task DeleteAuthorAsync(int ID);
    Task<AuthorReadDto> GetAuthorAsync(int ID);
    Task<AuthorDetailDto> GetAuthorDetailAsync(int ID);
    Task<IEnumerable<AuthorReadDto>> GetAuthorsAsync();
}
