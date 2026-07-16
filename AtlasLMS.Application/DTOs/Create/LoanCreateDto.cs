using System;
using System.ComponentModel.DataAnnotations;

namespace AtlasLMS.Application.DTOs.Create;

public class LoanCreateDto
{
    public int BookID { get; set; }
    public required string UserID { get; set; }
    public DateTime LifeTime { get; set; }
}
