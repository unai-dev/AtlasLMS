using AtlasLMS.Application.DTOs.Create;
using AtlasLMS.Application.DTOs.Read;
using AtlasLMS.Application.DTOs.Update;
using AtlasLMS.Domain.Entities;
using AutoMapper;

namespace AtlasLMS.API.Utils.Mappers;

public class BookingProfile : Profile
{
    public BookingProfile()
    {
        // Booking -> ReadDto
        CreateMap<Booking, BookingReadDto>()
            .ReverseMap();

        // CreateDto -> Booking
        CreateMap<BookingCreateDto, Booking>()
            .ForMember(dest => dest.ID, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.User, opt => opt.Ignore())
            .ForMember(dest => dest.Book, opt => opt.Ignore());

        // UpdateDto -> Booking
        CreateMap<BookingUpdateDto, Booking>()
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.User, opt => opt.Ignore())
            .ForMember(dest => dest.Book, opt => opt.Ignore());
    }
}
