using AtlasLMS.Domain.Entities.Common;

namespace AtlasLMS.Domain.Entities;

public class Author : BaseEntity
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;

    // Related Properties
    //
    //
    //
    //
    public List<Book> Books { get; set; } = new List<Book>();
}
