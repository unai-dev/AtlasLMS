namespace AtlasLMS.API.DTOs;

public class BookReadDto : BaseDto
{
    public string Title { get; set; } = string.Empty;
    public string ISBN { get; set; } = string.Empty;
    public string Synopsis { get; set; } = string.Empty;
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
