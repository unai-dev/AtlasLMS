using AtlasLMS.Data.Entities;
using AtlasLMS.Data.Entities.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace AtlasLMS.Application.DTOs.Create;

public class BookingCreateDto
{
    public DateTime StartTime { get; set; }
    public DateTime PickupDeadline { get; set; }
    public EBookingStatus Status { get; set; }
    public required string UserID { get; set; }
    public int BookID { get; set; }
}
