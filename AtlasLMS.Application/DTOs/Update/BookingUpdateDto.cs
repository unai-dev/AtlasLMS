using AtlasLMS.Data.Entities;
using AtlasLMS.Data.Entities.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace AtlasLMS.Application.DTOs.Update;

public class BookingUpdateDto
{
    public DateTime StartTime { get; set; }

    public DateTime PickupDeadline { get; set; }

    public EBookingStatus Status { get; set; }
    public required string UserID { get; set; }
    public int BookID { get; set; }

    public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;
}
