using Microsoft.AspNetCore.Identity;

namespace AtlasLMS.Domain.Entities;

public class User : IdentityUser
{
    public string CIF { get; set; } = null!;
    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }

    // Related Properties
    //
    //
    //
    public List<Booking> Bookings { get; set; } = new List<Booking>();
}