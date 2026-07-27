using AtlasLMS.Shared.DTOs.Common;
using AtlasLMS.Shared.Enums;

namespace AtlasLMS.Shared.DTOs.Read;

public class BookingReadDto : BaseDto
{
    public DateTime StartTime { get; set; }
    public DateTime PickupDeadline { get; set; }
    public EBookingStatus Status { get; set; }
}
