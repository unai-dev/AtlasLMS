using AtlasLMS.Domain.Entities;
using AtlasLMS.Shared.DTOs.Create;
using AtlasLMS.Shared.DTOs.Detail;
using AtlasLMS.Shared.DTOs.Read;
using AtlasLMS.Shared.DTOs.Update;

using AutoMapper;

namespace AtlasLMS.Application.MappingProfiles;

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