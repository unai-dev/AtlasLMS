using AtlasLMS.Application.DTOs.Common;
using AtlasLMS.Domain.Entities;

namespace AtlasLMS.Application.DTOs.Read;

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
    public User? User { get; set; }
}
