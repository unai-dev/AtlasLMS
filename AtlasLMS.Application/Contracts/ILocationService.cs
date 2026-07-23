using AtlasLMS.Shared.DTOs.Create;
using AtlasLMS.Shared.DTOs.Read;
using AtlasLMS.Shared.DTOs.Update;

namespace AtlasLMS.Application.Contracts;

public interface ILocationService
{
    Task<LocationReadDto> CreateLocationAsync(LocationCreateDto dto);
    Task<LocationReadDto> UpdateLocationAsync(int ID, LocationUpdateDto dto);
    Task DeleteLocationAsync(int ID);
    Task<IEnumerable<string>> GetAislesAsync();
    Task<IEnumerable<string>> GetColumnsByAisleAsync(string aisle);
    Task<LocationReadDto> GetLocationAsync(int ID);
    Task<IEnumerable<LocationReadDto>> GetLocationsAsync();
    Task<IEnumerable<string>> GetShelvesAsync(string aisle, string column);
}