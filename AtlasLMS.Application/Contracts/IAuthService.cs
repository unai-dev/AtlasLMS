using AtlasLMS.Shared.DTOs.Auth;
using AtlasLMS.Shared.DTOs.Create;
using AtlasLMS.Shared.Responses;
namespace AtlasLMS.Application.Contracts;

public interface IAuthService
{
    Task<AuthResponse> Login(LoginDto dto);
    Task<AuthResponse> Register(UserCreateDto dto);
}