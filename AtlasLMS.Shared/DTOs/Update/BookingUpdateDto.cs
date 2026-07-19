using AtlasLMS.Shared.Enums;

namespace AtlasLMS.Shared.DTOs.Update;

public class BookingUpdateDto
{
    public DateTime? StartTime { get; set; }
    public DateTime? PickupDeadline { get; set; }
    public EBookingStatus? Status { get; set; }
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    //Related properties
    //
    //
    //
    public string? UserID { get; set; }
    public int? BookID { get; set; }
}
