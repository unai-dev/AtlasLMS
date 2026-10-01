using AutoMapper;

using Unova.Domain.Entities;
using Unova.Shared.DTOs.Create;
using Unova.Shared.DTOs.Detail;
using Unova.Shared.DTOs.Read;
using Unova.Shared.DTOs.Update;

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

        // UpdateDto -> Center
        CreateMap<CenterUpdateDto, Center>().ReverseMap();
    }
}