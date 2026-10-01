using Unova.Shared.DTOs.Common;

namespace Unova.Shared.DTOs.Read;

public class BookReadDto : BaseDto
{
    public required string Title { get; set; }
    public required string ISBN { get; set; }
    public int Stock { get; set; }
    public string? Synopsis { get; set; }
    public DateTime PublicationAt { get; set; }
}
