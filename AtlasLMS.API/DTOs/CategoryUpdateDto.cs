using System.ComponentModel.DataAnnotations;

namespace AtlasLMS.API.DTOs;

public class CategoryUpdateDto
{
    public int ID { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    public DateTime? UpdatedAt { get; set; } = DateTime.Now;
}
