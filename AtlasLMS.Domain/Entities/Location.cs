using AtlasLMS.Domain.Entities.Common;

namespace AtlasLMS.Domain.Entities;

public class Location : BaseEntity
{
    public string Aisle { get; set; } = null!;
    public string Shelf { get; set; } = null!;
    public string Column { get; set; } = null!;
    public int LimitOfBooks { get; set; } = 5;

    // Related Properties
    //
    //
    //
    public List<Book> Books { get; set; } = new List<Book>();
}