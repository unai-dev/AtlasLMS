using AtlasLMS.Domain.Entities;
using AtlasLMS.Shared.DTOs.Create;
using AtlasLMS.Shared.DTOs.Detail;
using AtlasLMS.Shared.DTOs.Read;
using AtlasLMS.Shared.DTOs.Update;

using AutoMapper;

namespace AtlasLMS.API.Utils.Mappers;

public class AuthorProfile : Profile
{
    public AuthorProfile()
    {
        // Author -> ReadDto
        CreateMap<Author, AuthorReadDto>()
            .ReverseMap();

        // Author -> DetailDto
        CreateMap<Author, AuthorDetailDto>()
            .ReverseMap();

        // CreateDto -> Author
        CreateMap<AuthorCreateDto, Author>()
            .ForMember(dest => dest.ID, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.Books, opt => opt.Ignore());

        // UpdateDto -> Author
        CreateMap<AuthorUpdateDto, Author>()
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.Books, opt => opt.Ignore());
    }
}
