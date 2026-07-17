using AtlasLMS.Domain.Entities;
using AtlasLMS.Shared.DTOs.Create;
using AtlasLMS.Shared.DTOs.Read;
using AtlasLMS.Shared.DTOs.Update;

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
