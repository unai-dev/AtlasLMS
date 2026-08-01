using AtlasLMS.Shared.DTOs.Create;
using AtlasLMS.Shared.DTOs.Read;

namespace AtlasLMS.Blazor.Features.Authors.Contracts
{
    public interface IAuthorService
    {
        Task<IEnumerable<AuthorReadDto>> GetAuthorsAsync();
        Task<AuthorReadDto?> CreateAuthorAsync(AuthorCreateDto dto);
        Task<HttpResponseMessage> DeleteAuthorAsync(int ID);
    }
}