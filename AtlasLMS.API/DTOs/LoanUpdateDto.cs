using System.ComponentModel.DataAnnotations;

namespace AtlasLMS.API.DTOs;

public class LoanUpdateDto
{
    public int ID { get; set; }

    [Required]
    public int BookID { get; set; }

    public DateTime LifeTime { get; set; } = DateTime.Now.AddDays(14);

    public DateTime? UpdatedAt { get; set; } = DateTime.Now;
}
