using AtlasLMS.Shared.Enums;

namespace AtlasLMS.Shared.DTOs.Update;

public class BookingUpdateDto
{
    public DateTime? StartTime { get; set; }
    public DateTime? PickupDeadline { get; set; }
    public EBookingStatus? Status { get; set; }
    //Related properties
    //
    //
    //
    public string? UserID { get; set; }
    public int? BookID { get; set; }
}
