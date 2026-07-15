using AtlasLMS.API.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace AtlasLMS.API.Entities;

public class Author : BaseEntity
{
    [Required]
    [StringLength(55, ErrorMessage = "Name length can't be more than 55.", MinimumLength = 3)]
    public string FirstName { get; set; } = default!;

    [StringLength(55, ErrorMessage = "LastName length can't be more than 55.", MinimumLength = 3)]
    public string? LastName { get; set; }

    // Related Properties
    //
    //
    //
    //
    public List<Book> Books { get; set; } = new List<Book>();
}
