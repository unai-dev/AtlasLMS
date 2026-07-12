using System.ComponentModel.DataAnnotations;

namespace AtlasLMS.API.DTOs;

public class CategoryCreateDto
{
    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;
}
