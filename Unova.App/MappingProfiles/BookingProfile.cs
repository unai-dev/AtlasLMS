using AutoMapper;

namespace Unova.App.MappingProfiles;

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
