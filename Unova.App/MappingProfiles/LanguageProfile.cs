using AutoMapper;

namespace Unova.App.MappingProfiles;

public class LanguageProfile : Profile
{
    public LanguageProfile()
    {
        // Language -> ReadDto
        CreateMap<Language, LanguageReadDto>().ReverseMap();

        // Language -> DetailDto
        CreateMap<Language, LanguageDetailDto>().ReverseMap();

        // CreateDto -> Language
        CreateMap<LanguageCreateDto, Language>().ReverseMap();
    }
}
