using Microsoft.AspNetCore.Identity;

namespace AtlasLMS.Domain.Entities;

public class User : IdentityUser
{
    #region Properties
    public string CIF { get; set; } = null!;
    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    #endregion

    #region Related Properties
    public int LibraryID { get; set; }
    public Library? Library { get; set; }

    public List<Booking> Bookings { get; set; } = new List<Booking>();
    #endregion
}