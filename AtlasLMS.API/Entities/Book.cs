using AtlasLMS.API.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtlasLMS.API.Entities;

public class Book : BaseEntity
{
    [Required]
    [StringLength(55, ErrorMessage = "Title length can't be more than 55.", MinimumLength = 3)]
    public string Title { get; set; } = string.Empty;

    [Required]
    [StringLength(13, ErrorMessage = "The ISBN must be 13 digits long.")]
    public string ISBN { get; set; } = string.Empty;

    [StringLength(250)]
    public string Synopsis { get; set; } = string.Empty;

    [Required]
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