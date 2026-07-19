using AtlasLMS.Shared.DTOs.Create;
using AtlasLMS.Shared.Responses;
namespace AtlasLMS.Application.Contracts;

public interface IAuthService
{
    Task<AuthResponse> Login(UserCreateDto dto);
    Task<AuthResponse> Register(UserCreateDto dto);
}