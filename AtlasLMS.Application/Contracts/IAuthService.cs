using AtlasLMS.Shared.DTOs;
using AtlasLMS.Shared.DTOs.Create;
namespace AtlasLMS.Application.Contracts;

public interface IAuthService
{
    Task<AuthResponseDto> Login(UserCreateDto dto);
    Task<AuthResponseDto> Register(UserCreateDto dto);
}