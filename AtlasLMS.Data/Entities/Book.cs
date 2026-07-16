using AtlasLMS.Data.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtlasLMS.Data.Entities;

public class Book : BaseEntity
{
    public string Title { get; set; } = default!;
    public string ISBN { get; set; } = default!;
    public string? Synopsis { get; set; }
    public DateTime PublicationAt { get; set; }

    // Related Properties
    //
    //
    //
    [ForeignKey("AuthorID")]
    public int AuthorID { get; set; }
    public Author? Author { get; set; }

    [ForeignKey("CategoryID")]
    public int CategoryID { get; set; }
    public Category? Category { get; set; }

    [ForeignKey("LocationID")]
    public int LocationID { get; set; }
    public Location? Location { get; set; }
}