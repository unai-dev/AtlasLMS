using Microsoft.AspNetCore.Identity;

namespace Unova.Domain.Entities;

public class User : IdentityUser<int>
{
    #region Properties
    public string CIF { get; set; } = null!;
    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    #endregion

    #region Related Properties
    public int EnterpriseID { get; set; }
    public Enterprise? Enterprise { get; set; }

    public int LanguageID { get; set; }
    public Language? Language { get; set; }

    public int CenterID { get; set; }
    public Center? Center { get; set; }

    public List<Booking> Bookings { get; set; } = new List<Booking>();
    #endregion
}