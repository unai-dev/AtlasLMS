using AtlasLMS.Shared.DTOs.Common;
using AtlasLMS.Shared.Enums;

namespace AtlasLMS.Shared.DTOs.Read;

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
    public required string UserID { get; set; }
    public UserReadDto? User { get; set; }
}
