namespace AtlasLMS.API.DTOs;

public class BookReadDto : BaseDto
{
    public string Title { get; set; } = string.Empty;
    public string ISBN { get; set; } = string.Empty;
    public string Synopsis { get; set; } = string.Empty;
    public DateTime PublicationAt { get; set; }
    public int AuthorID { get; set; }
    public int CategoryID { get; set; }
}
