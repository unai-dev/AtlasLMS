using System.Net.Http.Json;

using AtlasLMS.Blazor.Features.Auth.Contracts;
using AtlasLMS.Shared.DTOs.Auth;
using AtlasLMS.Shared.DTOs.Create;
using AtlasLMS.Shared.Responses;

namespace AtlasLMS.Blazor.Features.Auth.Services;

public class AuthService : IAuthService
{
    private readonly HttpClient _http;

    public AuthService(HttpClient http)
    {
        _http = http;
    }

    public async Task<AuthResponse?> LoginAsync(LoginDto dto)
    {
        var response = await _http.PostAsJsonAsync("auth/login", dto);
        return await response.Content.ReadFromJsonAsync<AuthResponse>();
    }

    public async Task<AuthResponse?> RegisterAsync(UserCreateDto dto)
    {
        var result = await _http.PostAsJsonAsync("auth/register", dto);
        return await result.Content.ReadFromJsonAsync<AuthResponse>();
    }
}
