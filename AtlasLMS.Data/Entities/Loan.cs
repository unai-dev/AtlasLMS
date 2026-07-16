using AtlasLMS.Data.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtlasLMS.Data.Entities;

public class Loan : BaseEntity
{
    public DateTime LifeTime { get; set; }

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

    public Loan()
    {
        LifeTime = DateTime.UtcNow.AddDays(30);
    }
}
