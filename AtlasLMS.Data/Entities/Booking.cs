using AtlasLMS.Data.Entities.Common;
using AtlasLMS.Data.Entities.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtlasLMS.Data.Entities;

public class Booking : BaseEntity
{
    public DateTime StartTime { get; set; }
    public DateTime PickupDeadline { get; set; } 
    public EBookingStatus Status { get; set; } 

    // Related Properties
    //
    //
    //
    [ForeignKey("UserID")]
    public string UserID { get; set; } = default!;
    public User? User { get; set; }

    [ForeignKey("BookID")]
    public int BookID { get; set; }
    public Book? Book { get; set; }

    public Booking()
    {
        PickupDeadline = DateTime.UtcNow.AddDays(7);
        Status = EBookingStatus.Active;
    }
}
