using System.ComponentModel.DataAnnotations;

namespace AtlasLMS.API.DTOs;

public class LoanCreateDto
{
    [Required]
    public int BookID { get; set; }

    [Required]
    public int UserID { get; set; }

    public DateTime LifeTime { get; set; } = DateTime.UtcNow.AddDays(14);
}
