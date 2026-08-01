using AtlasLMS.Shared.DTOs.Create;
using AtlasLMS.Shared.DTOs.Read;

namespace AtlasLMS.Blazor.Features.Locations.Contracts
{
    public interface ILocationService
    {
        Task<IEnumerable<LocationReadDto>> GetLocationsAsync();
        Task<LocationReadDto?> CreateLocationAsync(LocationCreateDto dto);
        Task<HttpResponseMessage> DeleteLocationAsync(int ID);
    }
}