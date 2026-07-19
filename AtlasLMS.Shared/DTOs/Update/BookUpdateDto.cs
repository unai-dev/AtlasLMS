namespace AtlasLMS.Shared.DTOs.Update;

public class BookUpdateDto
{
    public string? Title { get; set; }
    public string? ISBN { get; set; }
    public string? Synopsis { get; set; }
    public DateTime? PublicationAt { get; set; }
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    //Related properties
    //
    //
    //
    public int? AuthorID { get; set; }
    public int? CategoryID { get; set; }
    public int? LocationID { get; set; }
}
