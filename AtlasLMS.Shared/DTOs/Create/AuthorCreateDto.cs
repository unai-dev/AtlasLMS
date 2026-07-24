using System.ComponentModel.DataAnnotations;

namespace AtlasLMS.Shared.DTOs.Create;

public class AuthorCreateDto
{
    [Required]
    [StringLength(55)]
    public string FirstName { get; set; } = string.Empty;
    [Required]
    [StringLength(55)]
    public string LastName { get; set; } = string.Empty;
}
