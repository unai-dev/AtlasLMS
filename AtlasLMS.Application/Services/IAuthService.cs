using AtlasLMS.Application.DTOs;
using AtlasLMS.Application.DTOs.Create;

namespace AtlasLMS.Application.Services;

public interface IAuthService
{
    Task<AuthResponseDto> Login(UserCreateDto dto);
    Task<AuthResponseDto> Register(UserCreateDto dto);
}