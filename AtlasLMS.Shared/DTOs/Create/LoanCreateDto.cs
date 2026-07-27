using System.ComponentModel.DataAnnotations;

using AtlasLMS.Shared.Enums;

namespace AtlasLMS.Shared.DTOs.Create;

public class LoanCreateDto
{
    public int LifeTime { get; set; }
    public ELoanStatus Status { get; set; }

    //Related properties
    //
    //
    //
    [Required]
    public string UserID { get; set; } = string.Empty;
    public int BookID { get; set; }
}
