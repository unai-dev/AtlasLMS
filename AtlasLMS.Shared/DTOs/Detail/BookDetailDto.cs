using AtlasLMS.Shared.DTOs.Common;
using AtlasLMS.Shared.DTOs.Read;

namespace AtlasLMS.Shared.DTOs.Detail;

public class BookDetailDto : BaseDto
{
    public required string Title { get; set; }
    public required string ISBN { get; set; }
    public string? Synopsis { get; set; }
    public DateTime PublicationAt { get; set; }

    // Related Properties
    //
    //
    //
    public int AuthorID { get; set; }
    public AuthorReadDto? Author { get; set; }
    public int CategoryID { get; set; }
    public CategoryReadDto? Category { get; set; }
    public int LocationID { get; set; }
    public LocationReadDto? Location { get; set; }
}
