using System.ComponentModel.DataAnnotations;

namespace AtlasLMS.API.DTOs;

public class LoanUpdateDto
{
    [Required]
    public int BookID { get; set; }

    public DateTime LifeTime { get; set; }

    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}
