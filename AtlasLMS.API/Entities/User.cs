using Microsoft.AspNetCore.Identity;

namespace AtlasLMS.API.Entities;

public class User : IdentityUser
{
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    // Related Properties
    //
    //
    //
    public List<Loan> Loans { get; set; } = new List<Loan>();
    public List<Booking> Bookings { get; set; } = new List<Booking>();

    /// <summary>
    /// Default constructor
    /// </summary>
    public User()
    {
        CreatedAt = DateTime.UtcNow;
    }
}