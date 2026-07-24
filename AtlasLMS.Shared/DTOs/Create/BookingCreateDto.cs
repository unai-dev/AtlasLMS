using System.ComponentModel.DataAnnotations;

using AtlasLMS.Shared.Enums;

namespace AtlasLMS.Shared.DTOs.Create;

public class BookingCreateDto
{
    [Required]
    public DateTime StartTime { get; set; }
    [Required]
    public DateTime PickupDeadline { get; set; }
    public EBookingStatus Status { get; set; }

    //Related properties
    //
    //
    //
    [Required]
    public string UserID { get; set; } = string.Empty;
    public int BookID { get; set; }
}
