using AtlasLMS.Domain.Entities.Common;

namespace AtlasLMS.Domain.Entities;

public class Location : BaseEntity
{
    public string Aisle { get; set; } = default!;
    public string Shelf { get; set; } = default!;
    public string Column { get; set; } = default!;

    // Related Properties
    //
    //
    //
    public List<Book> Books { get; set; } = new List<Book>();
}