using System.Net.Http.Json;

using AtlasLMS.Blazor.Features.Locations.Contracts;
using AtlasLMS.Shared.DTOs.Create;
using AtlasLMS.Shared.DTOs.Read;

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
    public async Task<HttpResponseMessage> CreateLocationAsync(LocationCreateDto dto) =>
        await _http.PostAsJsonAsync("locations", dto);

    public async Task<HttpResponseMessage> DeleteLocationAsync(int ID) =>
        await _http.DeleteAsync($"locations/{ID}");
}
