using AtlasLMS.Domain.Entities.Common;

namespace AtlasLMS.Domain.Entities;

public class Category : BaseEntity
{
    #region Properties
    public string Name { get; set; } = null!;
    #endregion

    #region Related Properties
    public List<Book> Books { get; set; } = new List<Book>();
    #endregion
}
