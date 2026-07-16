using AtlasLMS.Application.DTOs.Common;
using AtlasLMS.Data.Entities;
using AtlasLMS.Data.Entities.Enums;

namespace AtlasLMS.Application.DTOs.Read;

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
    public User? User { get; set; }
}
