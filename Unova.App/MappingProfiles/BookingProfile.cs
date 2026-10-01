using AtlasLMS.Domain.Entities;
using AtlasLMS.Shared.DTOs.Create;
using AtlasLMS.Shared.DTOs.Detail;
using AtlasLMS.Shared.DTOs.Read;

using AutoMapper;

namespace AtlasLMS.Application.MappingProfiles;

public class BookingProfile : Profile
{
    public BookingProfile()
    {
        // Booking -> ReadDto
        CreateMap<Booking, BookingReadDto>().ReverseMap();
        
        // Booking -> DetailDto
        CreateMap<Booking, BookingDetailDto>().ReverseMap();

        // CreateDto -> Booking
        CreateMap<BookingCreateDto, Booking>().ReverseMap();
    }
}
