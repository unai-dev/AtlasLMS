using AtlasLMS.Domain.Entities;
using AtlasLMS.Shared.DTOs.Create;
using AtlasLMS.Shared.DTOs.Detail;
using AtlasLMS.Shared.DTOs.Read;
using AtlasLMS.Shared.DTOs.Update;

using AutoMapper;

namespace AtlasLMS.Application.MappingProfiles;

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

        // UpdateDto -> Center
        CreateMap<CenterUpdateDto, Center>().ReverseMap();
    }
}