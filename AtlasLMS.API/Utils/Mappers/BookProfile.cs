using AtlasLMS.Application.DTOs.Create;
using AtlasLMS.Application.DTOs.Read;
using AtlasLMS.Application.DTOs.Update;
using AtlasLMS.Domain.Entities;
using AutoMapper;

namespace AtlasLMS.API.Utils.Mappers;

public class BookProfile : Profile
{
    public BookProfile()
    {
        // Book -> ReadDto
        CreateMap<Book, BookReadDto>()
            .ReverseMap();

        // CreateDto -> Book
        CreateMap<BookCreateDto, Book>()
            .ForMember(dest => dest.ID, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.Author, opt => opt.Ignore())
            .ForMember(dest => dest.Category, opt => opt.Ignore());

        // UpdateDto -> Book
        CreateMap<BookUpdateDto, Book>()
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.Author, opt => opt.Ignore())
            .ForMember(dest => dest.Category, opt => opt.Ignore());
    }
}
