using System.Net.Http.Json;

using AtlasLMS.Blazor.Features.Users.Contracts;
using AtlasLMS.Shared.DTOs.Create;
using AtlasLMS.Shared.DTOs.Detail;
using AtlasLMS.Shared.DTOs.Read;
using AtlasLMS.Shared.DTOs.Update;

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

    public async Task<UserReadDto?> GetUserAsync(string ID) =>
        await _http.GetFromJsonAsync<UserDetailDto>($"users/{ID}");

    public async Task<UserDetailDto?> GetUserDetailAsync(string ID) =>
        await _http.GetFromJsonAsync<UserDetailDto>($"users/detail/{ID}");

    public async Task<UserReadDto?> GetMe() =>
        await _http.GetFromJsonAsync<UserReadDto>("users/me");

    public async Task<HttpResponseMessage> CreateUserAsync(UserCreateDto dto) =>
        await _http.PostAsJsonAsync("users", dto);

    public async Task<HttpResponseMessage> UpdateUserAsync(string ID, UserUpdateDto dto) =>
        await _http.PutAsJsonAsync($"users/{ID}", dto);

    public async Task<HttpResponseMessage> DeleteUserAsync(string ID) =>
        await _http.DeleteAsync($"users/{ID}");
}
