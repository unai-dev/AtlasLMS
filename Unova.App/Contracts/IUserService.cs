using Unova.App.Contracts.Common;
using Unova.Shared.DTOs.Update;

namespace Unova.App.Contracts;

public interface IUserService : IUnovaContract<UserReadDto, UserDetailDto, UserCreateDto>
{
    Task<UserDetailDto> GetMe();
    Task<UserReadDto> UpdateUserAsync(int ID, UserUpdateDto dto);
}