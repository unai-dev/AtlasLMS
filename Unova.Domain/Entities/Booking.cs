using Unova.Domain.Entities.Common;

namespace Unova.Domain.Entities;

public class Booking : BaseEntity
{
    #region Properties
    public DateTime StartTime { get; set; }
    public DateTime PickupDeadline { get; set; }
    public EBookingStatus Status { get; set; } = EBookingStatus.Active;
    #endregion

    #region Related Properties
    public int UserID { get; set; }
    public User? User { get; set; }

    public int BookID { get; set; }
    public Book? Book { get; set; }
    #endregion
}

