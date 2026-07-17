using AtlasLMS.Shared.DTOs.Common;

namespace AtlasLMS.Shared.DTOs.Read;

public class LoanReadDto : BaseDto
{
    public DateTime StartDate { get; set; }
    public int LifeTime { get; set; }
    public DateTime DueDate { get; set; }

    // Related Properties
    //
    //
    //
    public int BookID { get; set; }
    public BookReadDto? Book { get; set; }
    public required string UserID { get; set; }
    public UserReadDto? User { get; set; }
}
