using AtlasLMS.API.Entities.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtlasLMS.API.Entities;

public class Booking : BaseEntity
{
    [Required]
    public DateTime StartTime { get; set; }
    public DateTime PickupDeadline { get; set; } = DateTime.UtcNow.AddDays(7);
    public EBookingStatus Status { get; set; } = EBookingStatus.Active;

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
}
