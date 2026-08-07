using AtlasLMS.Shared.DTOs.Create;
using AtlasLMS.Shared.DTOs.Detail;
using AtlasLMS.Shared.DTOs.Read;
using AtlasLMS.Shared.DTOs.Update;

namespace AtlasLMS.Blazor.Features.Authors.Contracts
{
    public interface IAuthorService
    {
        Task<IEnumerable<AuthorReadDto>> GetAuthorsAsync();
        Task<AuthorReadDto?> GetAuthorAsync(int ID);
        Task<AuthorDetailDto?> GetAuthorDetailAsync(int ID);
        Task<HttpResponseMessage> CreateAuthorAsync(AuthorCreateDto dto);
        Task<HttpResponseMessage> UpdateAuthorAsync(int ID, AuthorUpdateDto dto);
        Task<HttpResponseMessage> DeleteAuthorAsync(int ID);
    }
}