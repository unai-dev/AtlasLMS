namespace AtlasLMS.Shared.DTOs.Create;

public class LocationCreateDto
{
    public string Aisle { get; set; }  = string.Empty;
    public string Shelf { get; set; } = string.Empty;
    public string Column { get; set; } = string.Empty;
    public int LimitOfBooks { get; set; }
}
