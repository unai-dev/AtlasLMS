using AtlasLMS.Application.DTOs.Common;

namespace AtlasLMS.Application.DTOs.Read;

public class LocationReadDto : BaseDto
{
    public required string Aisle { get; set; }
    public required string Shelf { get; set; }
    public required string Column { get; set; }
}
