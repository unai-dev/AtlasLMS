using AtlasLMS.Shared.DTOs.Common;
using AtlasLMS.Shared.Enums;

namespace AtlasLMS.Shared.DTOs.Read;

public class LoanReadDto : BaseDto
{
    public DateTime StartDate { get; set; }
    public int LifeTime { get; set; }
    public DateTime DueDate { get; set; }
    public ELoanStatus Status { get; set; }
}
