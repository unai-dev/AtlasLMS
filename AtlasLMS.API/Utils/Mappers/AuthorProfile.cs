using AtlasLMS.Application.DTOs.Create;
using AtlasLMS.Application.DTOs.Detail;
using AtlasLMS.Application.DTOs.Read;
using AtlasLMS.Application.DTOs.Update;
using AtlasLMS.Domain.Entities;
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
