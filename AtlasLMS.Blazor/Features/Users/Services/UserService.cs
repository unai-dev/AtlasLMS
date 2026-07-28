using System.Net.Http.Json;

using AtlasLMS.Blazor.Features.Users.Contracts;
using AtlasLMS.Shared.DTOs.Read;

namespace AtlasLMS.Blazor.Features.Users.Services;

public class UserService : IUserService
{
    private readonly HttpClient _http;

    public UserService(HttpClient http)
    {
        _http = http;
    }

    public async Task<IEnumerable<UserReadDto>> GetUsersAsync() =>
        await _http.GetFromJsonAsync<IEnumerable<UserReadDto>>("users") ?? [];
}
