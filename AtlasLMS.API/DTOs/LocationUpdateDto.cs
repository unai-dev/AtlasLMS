using System.ComponentModel.DataAnnotations;

namespace AtlasLMS.API.DTOs;

public class LocationUpdateDto
{
    [Required]
    [StringLength(10)]
    public string Aisle { get; set; } = string.Empty;

    [Required]
    [StringLength(10)]
    public string Shelf { get; set; } = string.Empty;

    [Required]
    [StringLength(10)]
    public string Column { get; set; } = string.Empty;

    public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;
}
