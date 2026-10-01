using Unova.Shared.DTOs.Auth;
using Unova.Shared.Responses;
namespace Unova.App.Contracts;

public interface IAuthService
{
    Task<AuthResponse> Login(LoginDto dto);
    Task<AuthResponse> Register(UserCreateDto dto);
    Task MakeAdmin(ClaimDto dto);
    Task RemoveAdmin(ClaimDto dto);
}