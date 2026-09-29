using AtlasLMS.Shared.DTOs.Create;
using AtlasLMS.Shared.DTOs.Detail;
using AtlasLMS.Shared.DTOs.Read;

namespace AtlasLMS.Application.Contracts;

public interface IAddressService
{
    Task<AddressReadDto> GetAddressAsync(int ID);
    Task<IEnumerable<AddressReadDto>> GetAddressesAsync();
    Task<AddressDetailDto> GetAddressDetailAsync(int ID);
    Task<AddressReadDto> CreateAddressAsync(AddressCreateDto dto);
    Task DeleteAddressAsync(int ID);
}