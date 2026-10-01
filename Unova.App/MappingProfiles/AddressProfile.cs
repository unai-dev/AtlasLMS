using AutoMapper;

using Unova.Shared.DTOs.Update;

namespace Unova.App.MappingProfiles;

public class AddressProfile : Profile
{
    public AddressProfile()
    {
        // Address -> ReadDto
        CreateMap<Address, AddressReadDto>().ReverseMap();

        // Address -> DetailDto
        CreateMap<Address, AddressDetailDto>().ReverseMap();

        // CreateDto -> Address
        CreateMap<AddressCreateDto, Address>().ReverseMap();

        // UpdateDto -> Address
        CreateMap<AddressUpdateDto, Address>().ReverseMap();
    }
}