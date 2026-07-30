using AtlasLMS.Shared.DTOs.Read;

namespace AtlasLMS.Blazor.Features.Bookings.Contracts
{
    public interface IBookingService
    {
        Task<HttpResponseMessage> DeleteBookingAsync(int ID);
        Task<IEnumerable<BookingReadDto>> GetBookingsAsync();
    }
}