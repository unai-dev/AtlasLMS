using AtlasLMS.Application.DTOs.Common;

namespace AtlasLMS.Application.DTOs.Read;

public class BookReadDto : BaseDto
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
