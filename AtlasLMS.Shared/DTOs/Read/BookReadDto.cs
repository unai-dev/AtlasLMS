using AtlasLMS.Shared.DTOs.Common;

namespace AtlasLMS.Shared.DTOs.Read;

public class BookReadDto : BaseDto
{
    public required string Title { get; set; }
    public required string ISBN { get; set; }
    public int? Stock { get; set; }
    public string? Synopsis { get; set; }
    public DateTime PublicationAt { get; set; }
}
