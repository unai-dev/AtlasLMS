using AutoMapper;

namespace Unova.App.MappingProfiles;

public class AuthorProfile : Profile
{
    public AuthorProfile()
    {
        // Author -> ReadDto
        CreateMap<Author, AuthorReadDto>().ReverseMap();

        // Author -> DetailDto
        CreateMap<Author, AuthorDetailDto>().ReverseMap();

        // CreateDto -> Author
        CreateMap<AuthorCreateDto, Author>().ReverseMap();
    }
}
