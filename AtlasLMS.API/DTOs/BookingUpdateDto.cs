using AtlasLMS.API.Entities;
using System.ComponentModel.DataAnnotations;

namespace AtlasLMS.API.DTOs;

public class BookingUpdateDto
{
    [Required]
    public DateTime StartTime { get; set; }

    public DateTime PickupDeadline { get; set; } = DateTime.UtcNow.AddDays(7);

    public EBookingStatus Status { get; set; } = EBookingStatus.Active;

    [Required]
    public int UserID { get; set; }

    [Required]
    public int BookID { get; set; }

    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}
