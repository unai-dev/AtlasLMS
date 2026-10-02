using AutoMapper;

namespace Unova.App.MappingProfiles;

public class CenterProfile : Profile
{
    public CenterProfile()
    {
        // Center -> ReadDto
        CreateMap<Center, CenterReadDto>().ReverseMap();

        // Center -> DetailDto
        CreateMap<Center, CenterDetailDto>().ReverseMap();

        // CreateDto -> Center
        CreateMap<CenterCreateDto, Center>().ReverseMap();
    }
}