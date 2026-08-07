using AtlasLMS.Shared.DTOs.Create;
using AtlasLMS.Shared.DTOs.Detail;
using AtlasLMS.Shared.DTOs.Read;
using AtlasLMS.Shared.DTOs.Update;

namespace AtlasLMS.Blazor.Features.Locations.Contracts
{
    public interface ILocationService
    {
        Task<IEnumerable<LocationReadDto>> GetLocationsAsync();
        Task<LocationDetailDto?> GetLocationDetailAsync(int ID);
        Task<LocationReadDto?> GetLocationAsync(int ID);
        Task<HttpResponseMessage> CreateLocationAsync(LocationCreateDto dto);
        Task<HttpResponseMessage> UpdateLocationAsync(int ID, LocationUpdateDto dto);
        Task<HttpResponseMessage> DeleteLocationAsync(int ID);
    }
}