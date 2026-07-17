using System.ComponentModel.DataAnnotations.Schema;

using AtlasLMS.Domain.Entities.Common;
using AtlasLMS.Shared.Enums;

namespace AtlasLMS.Domain.Entities;

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
        Status = EBookingStatus.Active;
    }
}
