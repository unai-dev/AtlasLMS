using Unova.App.Contracts.Common;
using Unova.Shared.DTOs.Create;
using Unova.Shared.DTOs.Detail;
using Unova.Shared.DTOs.Read;
using Unova.Shared.DTOs.Update;

namespace Unova.App.Contracts;

public interface IUserService : IAtlasContract<UserReadDto, UserDetailDto, UserCreateDto>
{
    Task<UserDetailDto> GetMe();
    Task<UserReadDto> UpdateUserAsync(int ID, UserUpdateDto dto);
}