using AtlasLMS.Shared.DTOs.Read;

namespace AtlasLMS.Blazor.Features.Authors.Contracts
{
    public interface IAuthorService
    {
        Task<IEnumerable<AuthorReadDto>> GetAuthorsAsync();
        Task DeleteAuthorAsync(int ID);
    }
}