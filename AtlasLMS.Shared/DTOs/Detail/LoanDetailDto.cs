using AtlasLMS.Shared.DTOs.Read;
using AtlasLMS.Shared.Enums;

namespace AtlasLMS.Shared.DTOs.Detail;

public class LoanDetailDto
{
    public DateTime StartDate { get; set; }
    public int LifeTime { get; set; }
    public DateTime DueDate { get; set; }
    public ELoanStatus Status { get; set; }

    // Related Properties
    //
    //
    //
    public int BookID { get; set; }
    public BookReadDto? Book { get; set; }
    public required string UserID { get; set; }
    public UserReadDto? User { get; set; }
}
