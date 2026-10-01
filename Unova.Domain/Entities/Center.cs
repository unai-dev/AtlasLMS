using Unova.Domain.Entities.Common;

namespace Unova.Domain.Entities;

public class Center : BaseEntity
{
    #region Properties
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public string Abbreviation { get; set; } = null!;
    #endregion

    #region Related Properties
    public int EnterpriseID { get; set; }
    public Enterprise? Enterprise { get; set; }

    public List<Book> Books { get; set; } = new List<Book>();
    #endregion
}
