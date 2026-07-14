using AtlasLMS.API.DTOs;

namespace AtlasLMS.API.Services
{
    public interface IAuthorService
    {
        Task<AuthorReadDto> CreateAuthorAsync(AuthorCreateDto dto);
        Task DeleteAuthorAsync(int ID);
        Task<AuthorReadDto> GetAuthorAsync(int ID);
        Task<AuthorDetailDto> GetAuthorDetailAsync(int ID);
        Task<IEnumerable<AuthorReadDto>> GetAuthorsAsync();
    }
}