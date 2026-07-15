namespace AtlasLMS.API.DTOs;

public class LoanReadDto : BaseDto
{
    public DateTime LifeTime { get; set; }

    // Related Properties
    //
    //
    //
    public int BookID { get; set; }
    public BookReadDto? Book { get; set; }
    public int UserID { get; set; }
}
