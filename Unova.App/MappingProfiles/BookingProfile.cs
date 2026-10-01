using AutoMapper;

using Unova.Domain.Entities;
using Unova.Shared.DTOs.Create;
using Unova.Shared.DTOs.Detail;
using Unova.Shared.DTOs.Read;

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
