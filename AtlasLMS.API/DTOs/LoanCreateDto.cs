using System.ComponentModel.DataAnnotations;

namespace AtlasLMS.API.DTOs;

public class LoanCreateDto
{
    [Required]
    public int BookID { get; set; }

    public DateTime LifeTime { get; set; } = DateTime.Now.AddDays(14);
}
