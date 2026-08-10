using System.ComponentModel.DataAnnotations;

namespace AtlasLMS.Shared.DTOs.Auth;

public class ClaimDto
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
}
