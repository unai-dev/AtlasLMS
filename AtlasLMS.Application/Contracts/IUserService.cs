using AtlasLMS.Shared.DTOs.Create;
using AtlasLMS.Shared.DTOs.Detail;
using AtlasLMS.Shared.DTOs.Read;
using AtlasLMS.Shared.DTOs.Update;

namespace AtlasLMS.Application.Contracts;

public interface IUserService
{
    Task<IEnumerable<UserReadDto>> GetUsersAsync();
    Task<UserReadDto> GetUserAsync(int ID);
    Task<UserDetailDto> GetUserDetailAsync(int ID);
    Task<UserReadDto> GetMe();
    Task<UserReadDto> CreateUserAsync(UserCreateDto dto);
    Task<UserReadDto> UpdateUserAsync(int ID, UserUpdateDto dto);
    Task DeleteUserAsync(int ID);
}