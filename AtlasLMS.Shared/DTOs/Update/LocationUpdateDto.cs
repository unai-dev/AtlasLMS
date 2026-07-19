namespace AtlasLMS.Shared.DTOs.Update;

public class LocationUpdateDto
{
    public string? Aisle { get; set; }
    public string? Shelf { get; set; }
    public string? Column { get; set; }
    public int? LimitOfBooks { get; set; }
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}
