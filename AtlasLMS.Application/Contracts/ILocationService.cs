using AtlasLMS.Shared.DTOs.Create;
using AtlasLMS.Shared.DTOs.Detail;
using AtlasLMS.Shared.DTOs.Read;
using AtlasLMS.Shared.DTOs.Update;

namespace AtlasLMS.Application.Contracts;

public interface ILocationService
{
    Task<LocationReadDto> CreateLocationAsync(LocationCreateDto dto);
    Task<LocationReadDto> UpdateLocationAsync(int ID, LocationUpdateDto dto);
    Task DeleteLocationAsync(int ID);
    Task<LocationReadDto> GetLocationAsync(int ID);
    Task<LocationDetailDto> GetLocationDetailAsync(int ID);
    Task<IEnumerable<LocationReadDto>> GetLocationsAsync();
}