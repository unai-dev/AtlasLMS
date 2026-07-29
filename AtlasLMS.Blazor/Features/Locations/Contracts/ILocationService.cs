using AtlasLMS.Shared.DTOs.Read;

namespace AtlasLMS.Blazor.Features.Locations.Contracts
{
    public interface ILocationService
    {
        Task<IEnumerable<LocationReadDto>> GetLocationsAsync();
        Task<HttpResponseMessage> DeleteLocationAsync(int ID);
    }
}