using System.ComponentModel.DataAnnotations;

namespace AtlasLMS.Shared.DTOs.Create;

public class UserCreateDto
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
    [Required]
    [StringLength(9)]
    public string CIF { get; set; } = string.Empty;
    [Required]
    public string Password { get; set; } = string.Empty;
    [StringLength(25)]
    public string? UserName { get; set; }
}
