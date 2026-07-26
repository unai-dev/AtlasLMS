using AtlasLMS.Shared.DTOs.Read;
using AtlasLMS.Shared.Enums;

namespace AtlasLMS.Shared.DTOs.Detail;

public class BookingDetailDto
{
    public DateTime StartTime { get; set; }
    public DateTime PickupDeadline { get; set; }
    public EBookingStatus Status { get; set; }
    public int LifeTime { get; set; }

    // Related Properties
    //
    //
    //
    public int BookID { get; set; }
    public BookReadDto? Book { get; set; }
    public required string UserID { get; set; }
    public UserReadDto? User { get; set; }
}
