using System.ComponentModel.DataAnnotations;

namespace AtlasLMS.API.DTOs;

public class UserCreateDto
{
    [StringLength(55)]
    public string? UserName { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    [MinLength(8)]
    public string? Password { get; set; }
}
