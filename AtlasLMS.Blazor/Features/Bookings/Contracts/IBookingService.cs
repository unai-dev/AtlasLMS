using AtlasLMS.Shared.DTOs.Create;
using AtlasLMS.Shared.DTOs.Read;

namespace AtlasLMS.Blazor.Features.Bookings.Contracts
{
    public interface IBookingService
    {
        Task<IEnumerable<BookingReadDto>> GetBookingsAsync();
        Task<HttpResponseMessage> CreateBookingAsync(BookingCreateDto dto);
        Task<HttpResponseMessage> DeleteBookingAsync(int ID);
    }
}