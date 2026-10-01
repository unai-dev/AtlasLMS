using System;
using System.Collections.Generic;
using System.Text;

using AtlasLMS.Domain.Entities.Common;

namespace AtlasLMS.Domain.Entities;

public class Center: BaseEntity
{
    #region Properties
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public string Abbreviation { get; set; } = null!;
    #endregion

    #region Related Properties
    public int LibraryID { get; set; }
    public Library? Library { get; set; }

    public List<Book> Books { get; set; } = new List<Book>();
    #endregion
}
