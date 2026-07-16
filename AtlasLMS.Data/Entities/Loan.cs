using AtlasLMS.Data.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtlasLMS.Data.Entities;

public class Loan : BaseEntity
{
    public DateTime StartDate { get; set; }
    public int LifeTime { get; set; }
    public DateTime DueDate => StartDate.AddDays(LifeTime);

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
