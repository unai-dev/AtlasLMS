using AtlasLMS.Domain.Entities.Common;

namespace AtlasLMS.Domain.Entities;

public class Location : BaseEntity
{
    public required string Aisle { get; set; }
    public required string Shelf { get; set; }
    public required string Column { get; set; }
    public int? ShelfLimit { get; set; }

    // Related Properties
    //
    //
    //
    public List<Book> Books { get; set; } = new List<Book>();
}