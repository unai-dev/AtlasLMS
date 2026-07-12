using Microsoft.AspNetCore.Identity;

namespace AtlasLMS.API.Entities;

public class User : IdentityUser
{
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public User()
    {
        CreatedAt = DateTime.UtcNow;
    }
}