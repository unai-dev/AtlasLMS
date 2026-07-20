using System.ComponentModel.DataAnnotations.Schema;

using AtlasLMS.Domain.Entities.Common;

namespace AtlasLMS.Domain.Entities;

public class Book : BaseEntity
{
    public required string Title { get; set; }
    public required string ISBN { get; set; }
    public int? Stock { get; set; }
    public string? Synopsis { get; set; }
    public DateTime PublicationAt { get; set; }

    // Related Properties
    //
    //
    //
    [ForeignKey("AuthorID")]
    public required int AuthorID { get; set; }
    public Author? Author { get; set; }

    [ForeignKey("CategoryID")]
    public required int CategoryID { get; set; }
    public Category? Category { get; set; }

    [ForeignKey("LocationID")]
    public int? LocationID { get; set; }
    public Location? Location { get; set; }
}