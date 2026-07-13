using AtlasLMS.API.DTOs;

namespace AtlasLMS.API.Services;

public interface IAuthService
{
    Task<AuthResponseDto> Login(UserCreateDto dto);
    Task<AuthResponseDto> Register(UserCreateDto dto);
}