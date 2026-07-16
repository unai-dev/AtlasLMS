namespace AtlasLMS.Application.DTOs.Create;

public class LoanCreateDto
{
    public int BookID { get; set; }
    public required string UserID { get; set; }
    public DateTime StartDate { get; set; }
    public int LifeTime { get; set; }
}
