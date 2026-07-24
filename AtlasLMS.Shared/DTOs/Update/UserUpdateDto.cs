using System.ComponentModel.DataAnnotations;

namespace AtlasLMS.Shared.DTOs.Update;

public class UserUpdateDto
{
    [EmailAddress]
    public string? Email { get; set; }
    [StringLength(9)]
    public string? CIF { get; set; }
    [StringLength(25)]
    public string? UserName { get; set; }
}
