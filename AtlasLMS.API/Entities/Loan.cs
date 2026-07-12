using AtlasLMS.API.Entities.Common;

namespace AtlasLMS.API.Entities;

public class Loan : BaseEntity
{
    // 14 days loan period default
    public DateTime LifeTime { get; set; } = DateTime.Now.AddDays(14);

    // Related Properties
    //
    //
    //
    public int BookID { get; set; }
    public Book? Book { get; set; }
}
