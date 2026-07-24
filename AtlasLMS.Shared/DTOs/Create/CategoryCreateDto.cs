using System.ComponentModel.DataAnnotations;

namespace AtlasLMS.Shared.DTOs.Create;

public class CategoryCreateDto
{
    [Required]
    [StringLength(55)]
    public string Name { get; set; } = string.Empty;
}
