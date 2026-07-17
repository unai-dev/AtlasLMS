using AtlasLMS.Shared.DTOs.Create;
using AtlasLMS.Shared.DTOs.Detail;
using AtlasLMS.Shared.DTOs.Read;

namespace AtlasLMS.Application.Contracts
{
    public interface IUserService
    {
        Task<UserReadDto> CreateUserAsync(UserCreateDto dto);
        Task DeleteUserAsync(string ID);
        Task<UserReadDto> GetUserAsync(string ID);
        Task<UserDetailDto> GetUserDetailAsync(string ID);
        Task<IEnumerable<UserReadDto>> GetUsersAsync();
    }
}