using Unova.Domain.Entities.Common;

namespace Unova.Domain.Entities;

public class Copy : UnovaEntity
{
    #region Properties
    public string Code { get; set; } = null!;
    #endregion

    #region Related Properties
    public int BookID { get; set; }
    public Book? Book { get; set; }
    public int LocationID { get; set; }
    public Location? Location { get; set; }
    #endregion
}
