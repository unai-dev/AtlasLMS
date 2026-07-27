using AtlasLMS.Shared.DTOs.Common;

namespace AtlasLMS.Shared.DTOs.Read;

public class LoanReadDto : BaseDto
{
    public DateTime StartDate { get; set; }
    public int LifeTime { get; set; }
    public DateTime DueDate { get; set; }
    public int Status { get; set; }
}
