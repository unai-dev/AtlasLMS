using AtlasLMS.Application.DTOs.Create;
using AtlasLMS.Application.DTOs.Read;

namespace AtlasLMS.Application.Contracts
{
    public interface ILocationService
    {
        Task<LocationReadDto> CreateLocationAsync(LocationCreateDto dto);
        Task DeleteLocationAsync(int ID);
        Task<IEnumerable<string>> GetAislesAsync();
        Task<IEnumerable<string>> GetColumnsByAisleAsync(string aisle);
        Task<LocationReadDto> GetLocationAsync(int ID);
        Task<IEnumerable<LocationReadDto>> GetLocationsAsync();
        Task<IEnumerable<string>> GetShelvesAsync(string aisle, string column);
    }
}