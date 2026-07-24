using AtlasLMS.Domain.Entities;
using AtlasLMS.Shared.DTOs.Create;
using AtlasLMS.Shared.DTOs.Read;

namespace AtlasLMS.Application.Contracts
{
    public interface IBookingService
    {
        Task<BookingReadDto> CreateBookingAsync(BookingCreateDto dto);
        Task DeleteBookingAsync(int bookingID);
        Task<BookingReadDto> GetBookingAsync(int ID);
        Task<BookingReadDto> GetBookingByBookAsync(int bookID);
        Task<IEnumerable<BookingReadDto>> GetBookingsAsync();
        Task<IEnumerable<BookingReadDto>> GetBookingsByStatusAsync(EBookingStatus status);
        Task<IEnumerable<BookingReadDto>> GetBookingsByUserAsync(string userID);
    }
}