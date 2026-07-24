using AtlasLMS.Shared.DTOs.Auth;
using AtlasLMS.Shared.DTOs.Create;
using AtlasLMS.Shared.Responses;

namespace AtlasLMS.Blazor.Features.Auth.Contracts
{
    public interface IAuthService
    {
        Task<AuthResponse?> LoginAsync(LoginDto dto);
        Task<AuthResponse?> RegisterAsync(UserCreateDto dto);
    }
}