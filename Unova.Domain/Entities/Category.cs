using Unova.Domain.Entities.Common;

namespace Unova.Domain.Entities;

public class Category : UnovaEntity
{
    #region Properties
    public string Name { get; set; } = null!;
    #endregion

    #region Related Properties
    public List<Book> Books { get; set; } = new List<Book>();
    #endregion
}
