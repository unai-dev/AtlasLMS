using AtlasLMS.API.Entities;

namespace AtlasLMS.API.DTOs;

public class BookingReadDto : BaseDto
{
    public DateTime StartTime { get; set; }
    public DateTime PickupDeadline { get; set; }
    public EBookingStatus Status { get; set; }

    // Related Properties
    //
    //
    //
    public int BookID { get; set; }
    public BookReadDto? Book { get; set; }
    public int UserID { get; set; }
}
