using AtlasLMS.API.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace AtlasLMS.API.Entities;

public class Category : BaseEntity
{
    public string Name { get; set; } = default!;

    // Related Properties
    //
    //
    //
    public List<Book> Books { get; set; } = new List<Book>();
}
