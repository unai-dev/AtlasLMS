using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AtlasLMS.API.Entities.Common;

namespace AtlasLMS.API.Entities;

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