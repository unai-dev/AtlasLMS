using AutoMapper;

namespace Unova.App.MappingProfiles;

public class EnterpriseProfile : Profile
{
    public EnterpriseProfile()
    {
        // Enterprise -> ReadDto
        CreateMap<Enterprise, EnterpriseReadDto>().ReverseMap();

        // Enterprise -> DetailDto
        CreateMap<Enterprise, EnterpriseDetailDto>().ReverseMap();

        // CreateDto -> Enterprise
        CreateMap<EnterpriseCreateDto, Enterprise>().ReverseMap();
    }
}