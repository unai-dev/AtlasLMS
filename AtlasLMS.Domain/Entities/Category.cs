using AtlasLMS.Domain.Entities.Common;

namespace AtlasLMS.Domain.Entities;

public class Category : BaseEntity
{
    public required string Name { get; set; }

    // Related Properties
    //
    //
    //
    public List<Book> Books { get; set; } = new List<Book>();
}
