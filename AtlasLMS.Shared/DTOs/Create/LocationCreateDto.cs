namespace AtlasLMS.Shared.DTOs.Create;

public class LocationCreateDto
{
    public required string Aisle { get; set; }
    public required string Shelf { get; set; }
    public required string Column { get; set; }
    public int LimitOfBooks { get; set; }
}
