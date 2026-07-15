using AtlasLMS.API.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtlasLMS.API.Entities;

public class Loan : BaseEntity
{
    // 14 days loan period default
    public DateTime LifeTime { get; set; } = DateTime.UtcNow.AddDays(14);

    // Related Properties
    //
    //
    //
    [ForeignKey("BookID")]
    public int BookID { get; set; }
    public Book? Book { get; set; }

    [ForeignKey("UserID")]
    public string UserID { get; set; } = default!;
    public User? User { get; set; }
}
