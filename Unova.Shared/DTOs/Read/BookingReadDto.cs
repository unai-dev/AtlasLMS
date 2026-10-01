using Unova.Shared.DTOs.Common;

namespace Unova.Shared.DTOs.Read;

public class BookingReadDto : BaseDto
{
    public DateTime StartTime { get; set; }
    public DateTime PickupDeadline { get; set; }
    public int Status { get; set; }
}
