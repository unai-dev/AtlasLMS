using AtlasLMS.Data.Entities.Common;

namespace AtlasLMS.Data.Entities;

public class Category : BaseEntity
{
    public string Name { get; set; } = default!;

    // Related Properties
    //
    //
    //
    public List<Book> Books { get; set; } = new List<Book>();
}
