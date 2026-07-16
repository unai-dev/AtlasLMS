using AtlasLMS.API.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace AtlasLMS.API.Entities;

public class Author : BaseEntity
{
    public string FirstName { get; set; } = default!;
    public string? LastName { get; set; }

    // Related Properties
    //
    //
    //
    //
    public List<Book> Books { get; set; } = new List<Book>();
}
