namespace AtlasLMS.Shared.DTOs.Update;

public class LoanUpdateDto
{
    public DateTime? StartDate { get; set; }
    public int? LifeTime { get; set; }
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    //Related properties
    //
    //
    //
    public int? BookID { get; set; }
    public string? UserID { get; set; }
}
