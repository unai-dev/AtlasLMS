using System.ComponentModel.DataAnnotations;

namespace AtlasLMS.API.DTOs;

public class LoanUpdateDto
{
    [Required]
    public int BookID { get; set; }

    [Required]
    public int UserID { get; set; }

    public DateTime LifeTime { get; set; } = DateTime.UtcNow.AddDays(14);

    public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;
}
