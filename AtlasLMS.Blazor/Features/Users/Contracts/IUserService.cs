using AtlasLMS.Shared.DTOs.Read;

namespace AtlasLMS.Blazor.Features.Users.Contracts
{
    public interface IUserService
    {
        Task<IEnumerable<UserReadDto>> GetUsersAsync();
    }
}