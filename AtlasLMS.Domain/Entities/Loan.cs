using System.ComponentModel.DataAnnotations.Schema;

using AtlasLMS.Domain.Entities.Common;

namespace AtlasLMS.Domain.Entities;

public class Loan : BaseEntity
{
    public DateTime StartDate { get; set; }
    public int LifeTime { get; set; }
    public DateTime DueDate { get; set; }

    // Related Properties
    //
    //
    //
    [ForeignKey("BookID")]
    public required int BookID { get; set; }
    public Book? Book { get; set; }

    [ForeignKey("UserID")]
    public required string UserID { get; set; }
    public User? User { get; set; }
}
