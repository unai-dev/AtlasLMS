using System;
using System.ComponentModel.DataAnnotations;

namespace AtlasLMS.Application.DTOs.Update;

public class LoanUpdateDto
{
    public int BookID { get; set; }
    public required string UserID { get; set; }
    public DateTime StartDate { get; set; }
    public int LifeTime { get; set; }
    public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;
}
