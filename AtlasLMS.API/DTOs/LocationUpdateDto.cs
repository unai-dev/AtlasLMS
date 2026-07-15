using System.ComponentModel.DataAnnotations;

namespace AtlasLMS.API.DTOs;

public class LocationUpdateDto
{
    [Required]
    [StringLength(55)]
    public string Aisle { get; set; } = string.Empty;

    [Required]
    [StringLength(55)]
    public string Shelf { get; set; } = string.Empty;

    [Required]
    [StringLength(55)]
    public string Column { get; set; } = string.Empty;

    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}
