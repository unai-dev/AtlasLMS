using Microsoft.AspNetCore.Identity;

namespace AtlasLMS.Domain.Entities;

public class User : IdentityUser
{
    public required string CIF { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }

    // Related Properties
    //
    //
    //
    public List<Loan> Loans { get; set; } = new List<Loan>();
    public List<Booking> Bookings { get; set; } = new List<Booking>();
}