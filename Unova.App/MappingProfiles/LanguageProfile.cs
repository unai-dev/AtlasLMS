using AutoMapper;

using Unova.Shared.DTOs.Update;

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

        // UpdateDto -> Language
        CreateMap<LanguageUpdateDto, Language>().ReverseMap();
    }
}
