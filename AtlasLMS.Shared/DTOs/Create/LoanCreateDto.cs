namespace AtlasLMS.Shared.DTOs.Create;

public class LoanCreateDto
{
    public DateTime StartDate { get; set; }
    public int LifeTime { get; set; }

    //Related properties
    //
    //
    //
    public int BookID { get; set; }
    public string UserID { get; set; } = string.Empty;
}
