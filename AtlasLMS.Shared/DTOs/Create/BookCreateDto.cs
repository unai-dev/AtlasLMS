namespace AtlasLMS.Shared.DTOs.Create;

public class BookCreateDto
{
    public string Title { get; set; } = string.Empty;
    public string ISBN { get; set; } = string.Empty;
    public int? Stock { get; set; }
    public string? Synopsis { get; set; }
    public DateTime PublicationAt { get; set; }

    //Related properties
    //
    //
    //
    public int AuthorID { get; set; }
    public int CategoryID { get; set; }
    public int? LocationID { get; set; }
}
