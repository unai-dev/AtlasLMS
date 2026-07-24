using System.ComponentModel.DataAnnotations;

namespace AtlasLMS.Shared.DTOs.Update;

public class LocationUpdateDto
{
    [StringLength(5)]
    public string? Aisle { get; set; }
    [StringLength(5)]
    public string? Shelf { get; set; }
    [StringLength(5)]
    public string? Column { get; set; }
    public int? LimitOfBooks { get; set; }
}
