namespace AtlasLMS.Shared.DTOs.Create;

public class BookCreateDto
{
    public required string Title { get; set; }
    public required string ISBN { get; set; }
    public string? Synopsis { get; set; }
    public DateTime PublicationAt { get; set; }
    public int AuthorID { get; set; }
    public int CategoryID { get; set; }
    public int LocationID { get; set; }
}
