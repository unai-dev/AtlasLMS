using AtlasLMS.Shared.DTOs.Create;
using AtlasLMS.Shared.DTOs.Detail;
using AtlasLMS.Shared.DTOs.Read;
using AtlasLMS.Shared.DTOs.Update;

namespace AtlasLMS.Blazor.Features.Users.Contracts
{
    public interface IUserService
    {
        Task<IEnumerable<UserReadDto>> GetUsersAsync();
        Task<UserDetailDto?> GetUserDetailAsync(string ID);
        Task<UserReadDto?> GetUserAsync(string ID);
        Task<UserReadDto?> GetMe();
        Task<HttpResponseMessage> CreateUserAsync(UserCreateDto dto);
        Task<HttpResponseMessage> UpdateUserAsync(string ID, UserUpdateDto dto);
        Task<HttpResponseMessage> DeleteUserAsync(string ID);
    }
}