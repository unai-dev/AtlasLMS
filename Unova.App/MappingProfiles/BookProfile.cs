using AtlasLMS.Domain.Entities;
using AtlasLMS.Shared.DTOs.Create;
using AtlasLMS.Shared.DTOs.Detail;
using AtlasLMS.Shared.DTOs.Read;
using AtlasLMS.Shared.DTOs.Update;

using AutoMapper;

namespace AtlasLMS.Application.MappingProfiles;

public class BookProfile : Profile
{
    public BookProfile()
    {
        // Book -> ReadDto
        CreateMap<Book, BookReadDto>().ReverseMap();

        // Book -> DetailDto
        CreateMap<Book, BookDetailDto>()
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category!.Name))
            .ReverseMap();

        // CreateDto -> Book
        CreateMap<BookCreateDto, Book>().ReverseMap();

        // UpdateDto -> Book
        CreateMap<BookUpdateDto, Book>().ReverseMap();
    }
}
