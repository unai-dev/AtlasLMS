using AutoMapper;

using Unova.Domain.Entities;
using Unova.Shared.DTOs.Create;
using Unova.Shared.DTOs.Detail;
using Unova.Shared.DTOs.Read;
using Unova.Shared.DTOs.Update;

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

        // UpdateDto -> Author
        CreateMap<AuthorUpdateDto, Author>().ReverseMap();
    }
}
