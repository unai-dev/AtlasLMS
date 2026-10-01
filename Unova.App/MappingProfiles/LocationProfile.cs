using AutoMapper;

using Unova.Shared.DTOs.Update;

namespace Unova.App.MappingProfiles;

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
