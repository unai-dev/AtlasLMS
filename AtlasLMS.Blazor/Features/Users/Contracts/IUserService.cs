using AtlasLMS.Shared.DTOs.Create;
using AtlasLMS.Shared.DTOs.Detail;
using AtlasLMS.Shared.DTOs.Read;

namespace AtlasLMS.Blazor.Features.Users.Contracts
{
    public interface IUserService
    {
        Task<IEnumerable<UserReadDto>> GetUsersAsync();
        Task<UserDetailDto?> GetUserAsync(string ID);
        Task<UserReadDto?> GetMe();
        Task<HttpResponseMessage> CreateUserAsync(UserCreateDto dto);
        Task<HttpResponseMessage> DeleteUserAsync(string ID);
    }
}