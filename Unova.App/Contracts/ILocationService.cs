using Unova.App.Contracts.Common;
using Unova.Shared.DTOs.Update;

namespace Unova.App.Contracts;

public interface ILocationService : IUnovaContract<LocationReadDto, LocationDetailDto, LocationCreateDto>
{
    Task<LocationReadDto> UpdateLocationAsync(int ID, LocationUpdateDto dto);
}