using AtlasLMS.Application.Contracts.Common;
using AtlasLMS.Shared.DTOs.Create;
using AtlasLMS.Shared.DTOs.Detail;
using AtlasLMS.Shared.DTOs.Read;
using AtlasLMS.Shared.DTOs.Update;

namespace AtlasLMS.Application.Contracts;

public interface IUserService : IAtlasContract<UserReadDto, UserDetailDto, UserCreateDto>
{
    Task<UserDetailDto> GetMe();
    Task<UserReadDto> UpdateUserAsync(int ID, UserUpdateDto dto);
}