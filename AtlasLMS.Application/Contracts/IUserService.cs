using AtlasLMS.Shared.DTOs.Create;
using AtlasLMS.Shared.DTOs.Detail;
using AtlasLMS.Shared.DTOs.Read;
using AtlasLMS.Shared.DTOs.Update;

namespace AtlasLMS.Application.Contracts
{
    public interface IUserService
    {
        Task<UserReadDto> CreateUserAsync(UserCreateDto dto);
        Task<UserReadDto> UpdateUserAsync(string ID, UserUpdateDto dto);
        Task DeleteUserAsync(string ID);
        Task<UserReadDto> GetUserAsync(string ID);
        Task<UserDetailDto> GetUserLoansAsync(string ID);
        Task<UserDetailDto> GetUserBookingsAsync(string ID);
        Task<IEnumerable<UserReadDto>> GetUsersAsync();
    }
}