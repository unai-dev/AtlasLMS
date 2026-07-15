using System.ComponentModel.DataAnnotations;

namespace AtlasLMS.API.DTOs;

public class CategoryUpdateDto
{
    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;
}
