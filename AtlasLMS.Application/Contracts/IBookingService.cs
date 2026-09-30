using AtlasLMS.Application.Contracts.Common;
using AtlasLMS.Domain.Entities;
using AtlasLMS.Shared.DTOs.Create;
using AtlasLMS.Shared.DTOs.Detail;
using AtlasLMS.Shared.DTOs.Read;

namespace AtlasLMS.Application.Contracts;

public interface IBookingService : IAtlasContract<BookingReadDto, BookingDetailDto, BookingCreateDto>
{
    Task<IEnumerable<BookingReadDto>> GetBookingsByUserAsync(int userID);
}