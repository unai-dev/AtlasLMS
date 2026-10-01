using Unova.App.Contracts.Common;

namespace Unova.App.Contracts;

public interface IBookingService : IUnovaContract<BookingReadDto, BookingDetailDto, BookingCreateDto>
{
    Task<IEnumerable<BookingReadDto>> GetBookingsByUserAsync(int userID);
}