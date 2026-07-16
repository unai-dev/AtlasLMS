using AtlasLMS.Application.DTOs.Common;
using AtlasLMS.Data.Entities;

namespace AtlasLMS.Application.DTOs.Read;

public class LoanReadDto : BaseDto
{
    public DateTime LifeTime { get; set; }

    // Related Properties
    //
    //
    //
    public int BookID { get; set; }
    public BookReadDto? Book { get; set; }
    public required string UserID { get; set; }
    public User? User { get; set; }
}
