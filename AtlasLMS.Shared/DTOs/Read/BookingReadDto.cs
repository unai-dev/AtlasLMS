using AtlasLMS.Shared.DTOs.Common;

namespace AtlasLMS.Shared.DTOs.Read;

public class BookingReadDto : BaseDto
{
    public DateTime StartTime { get; set; }
    public DateTime PickupDeadline { get; set; }
    public int Status { get; set; }
}
