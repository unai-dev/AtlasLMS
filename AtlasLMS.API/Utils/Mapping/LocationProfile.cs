using AtlasLMS.API.DTOs;
using AtlasLMS.API.Entities;
using AutoMapper;

namespace AtlasLMS.API.Utils.Mapping;

public class LocationProfile : Profile
{
    public LocationProfile()
    {
        // Location -> ReadDto
        CreateMap<Location, LocationReadDto>()
            .ReverseMap();

        // CreateDto -> Location
        CreateMap<LocationCreateDto, Location>()
            .ForMember(dest => dest.ID, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore());

        // UpdateDto -> Location
        CreateMap<LocationUpdateDto, Location>()
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore());
    }
}
