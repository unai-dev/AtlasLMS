using System;

namespace AtlasLMS.Application.DTOs.Update;

public class LocationUpdateDto
{
    public required string Aisle { get; set; }

    public required string Shelf { get; set; }

    public required string Column { get; set; }
    public int LimitOfBooks { get; set; }

    public DateTime UpdatedAt { get; set; }
}
