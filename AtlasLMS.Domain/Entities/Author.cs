using AtlasLMS.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace AtlasLMS.Domain.Entities;

public class Author : BaseEntity
{
    public required string FirstName { get; set; }
    public string? LastName { get; set; }

    // Related Properties
    //
    //
    //
    //
    public List<Book> Books { get; set; } = new List<Book>();
}
