using Unova.App.Contracts.Common;

namespace Unova.App.Contracts;

public interface IUserService : IUnovaContract<UserReadDto, UserDetailDto, UserCreateDto>
{
    Task<UserDetailDto> GetMe();
}
