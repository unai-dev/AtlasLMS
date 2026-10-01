using AutoMapper;

namespace Unova.App.MappingProfiles;

public class CopyProfile : Profile
{
    public CopyProfile()
    {
        // Copy -> ReadDto
        CreateMap<Copy, CopyReadDto>().ReverseMap();

        // Copy -> DetailDto
        CreateMap<Copy, CopyDetailDto>()
            .ReverseMap();

        // CreateDto -> Copy
        CreateMap<CopyCreateDto, Copy>().ReverseMap();
    }
}
