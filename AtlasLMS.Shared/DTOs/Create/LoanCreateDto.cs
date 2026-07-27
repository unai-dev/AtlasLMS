using System.ComponentModel.DataAnnotations;

namespace AtlasLMS.Shared.DTOs.Create;

public class LoanCreateDto
{
    public int LifeTime { get; set; }

    //Related properties
    //
    //
    //
    [Required]
    public string UserID { get; set; } = string.Empty;
    public int BookID { get; set; }
}
