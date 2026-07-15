using AtlasLMS.API.Entities;

namespace AtlasLMS.API.DTOs;

public class BookingReadDto : BaseDto
{
    public DateTime StartTime { get; set; }
    public DateTime PickupDeadline { get; set; }
    public EBookingStatus Status { get; set; }
    public int UserID { get; set; }
    public int BookID { get; set; }
}
