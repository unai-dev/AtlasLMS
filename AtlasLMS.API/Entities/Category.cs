using AtlasLMS.API.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace AtlasLMS.API.Entities;

public class Category : BaseEntity
{
    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    // Related Properties
    //
    //
    //
    public List<Book> Books { get; set; } = new List<Book>();
}
