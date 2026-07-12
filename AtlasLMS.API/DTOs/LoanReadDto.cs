namespace AtlasLMS.API.DTOs;

public class LoanReadDto : BaseDto
{
    public DateTime LifeTime { get; set; }
    public int BookID { get; set; }
}
