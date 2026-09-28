using AtlasLMS.Domain.Entities;
using AtlasLMS.Shared.DTOs.Create;
using AtlasLMS.Shared.DTOs.Detail;
using AtlasLMS.Shared.DTOs.Read;
using AtlasLMS.Shared.DTOs.Update;

using AutoMapper;

namespace AtlasLMS.Application.MappingProfiles;

public class LocationProfile : Profile
{
    public LocationProfile()
    {
        // Location -> ReadDto
        CreateMap<Location, LocationReadDto>().ReverseMap();

        // Location -> ReadDto
        CreateMap<Location, LocationDetailDto>().ReverseMap();

        // CreateDto -> Location
        CreateMap<LocationCreateDto, Location>().ReverseMap();

        // UpdateDto -> Location
        CreateMap<LocationUpdateDto, Location>().ReverseMap();
    }
}
