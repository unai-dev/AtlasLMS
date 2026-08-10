using AtlasLMS.Shared.DTOs.Read;

namespace AtlasLMS.Shared.DTOs.Detail;

public class BookDetailDto : BookReadDto
{
    // Related Properties
    //
    //
    //
    public int AuthorID { get; set; }
    public AuthorReadDto? Author { get; set; }
    public int CategoryID { get; set; }
    public required string CategoryName { get; set; }
    public CategoryReadDto? Category { get; set; }
    public int LocationID { get; set; }
    public LocationReadDto? Location { get; set; }
}
