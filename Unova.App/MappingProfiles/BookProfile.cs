using AutoMapper;

using Unova.Domain.Entities;
using Unova.Shared.DTOs.Create;
using Unova.Shared.DTOs.Detail;
using Unova.Shared.DTOs.Read;
using Unova.Shared.DTOs.Update;

namespace Unova.App.MappingProfiles;

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
