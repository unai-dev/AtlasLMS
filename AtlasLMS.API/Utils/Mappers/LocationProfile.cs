using AtlasLMS.Application.DTOs.Create;
using AtlasLMS.Application.DTOs.Read;
using AtlasLMS.Application.DTOs.Update;
using AtlasLMS.Data.Entities;
using AutoMapper;

namespace AtlasLMS.API.Utils.Mappers;

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
