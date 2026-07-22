using AtlasLMS.Shared.Enums;

namespace AtlasLMS.Shared.DTOs.Create;

public class BookingCreateDto
{
    public DateTime StartTime { get; set; }
    public DateTime PickupDeadline { get; set; }
    public EBookingStatus Status { get; set; }

    //Related properties
    //
    //
    //
    public string UserID { get; set; } = string.Empty;
    public int BookID { get; set; }
}
