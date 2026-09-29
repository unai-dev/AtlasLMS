using AtlasLMS.Domain.Entities;
using AtlasLMS.Shared.DTOs.Create;
using AtlasLMS.Shared.DTOs.Detail;
using AtlasLMS.Shared.DTOs.Read;

namespace AtlasLMS.Application.Contracts;

public interface IBookingService
{
    Task<IEnumerable<BookingReadDto>> GetBookingsAsync();
    Task<IEnumerable<BookingReadDto>> GetBookingsByUserAsync(int userID);
    Task<BookingReadDto> GetBookingAsync(int ID);
    Task<BookingDetailDto> GetBookingDetailAsync(int ID);
    Task<BookingReadDto> CreateBookingAsync(BookingCreateDto dto);
    Task DeleteBookingAsync(int bookingID);
}