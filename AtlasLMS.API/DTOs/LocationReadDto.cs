namespace AtlasLMS.API.DTOs;

public class LocationReadDto : BaseDto
{
    public string Aisle { get; set; } = string.Empty;
    public string Shelf { get; set; } = string.Empty;
    public string Column { get; set; } = string.Empty;
}
