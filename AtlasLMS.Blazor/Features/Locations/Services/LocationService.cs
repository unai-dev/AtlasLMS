using System.Net.Http.Json;

using AtlasLMS.Blazor.Features.Locations.Contracts;
using AtlasLMS.Shared.DTOs.Create;
using AtlasLMS.Shared.DTOs.Detail;
using AtlasLMS.Shared.DTOs.Read;
using AtlasLMS.Shared.DTOs.Update;

namespace AtlasLMS.Blazor.Features.Locations.Services;

public class LocationService : ILocationService
{
    private readonly HttpClient _http;

    public LocationService(HttpClient http)
    {
        _http = http;
    }

    public async Task<IEnumerable<LocationReadDto>> GetLocationsAsync() =>
        await _http.GetFromJsonAsync<IEnumerable<LocationReadDto>>("locations") ?? [];

    public async Task<LocationReadDto?> GetLocationAsync(int ID) =>
        await _http.GetFromJsonAsync<LocationReadDto>($"locations/{ID}");

    public async Task<LocationDetailDto?> GetLocationDetailAsync(int ID) =>
        await _http.GetFromJsonAsync<LocationDetailDto>($"locations/detail/{ID}");

    public async Task<HttpResponseMessage> CreateLocationAsync(LocationCreateDto dto) =>
        await _http.PostAsJsonAsync("locations", dto);

    public async Task<HttpResponseMessage> UpdateLocationAsync(int ID, LocationUpdateDto dto) =>
        await _http.PutAsJsonAsync($"locations/{ID}", dto);

    public async Task<HttpResponseMessage> DeleteLocationAsync(int ID) =>
        await _http.DeleteAsync($"locations/{ID}");
}
