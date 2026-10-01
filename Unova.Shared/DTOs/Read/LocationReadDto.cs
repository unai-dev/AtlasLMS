using Unova.Shared.DTOs.Common;

namespace Unova.Shared.DTOs.Read;

public class LocationReadDto : BaseDto
{
    public required string Aisle { get; set; }
    public required string Shelf { get; set; }
    public required string Column { get; set; }
    public int LimitOfBooks { get; set; }

    public string Location => $"{Aisle}/{Column}/{Shelf}";
}
