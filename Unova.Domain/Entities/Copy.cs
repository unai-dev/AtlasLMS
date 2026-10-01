using Unova.Domain.Entities.Common;

namespace Unova.Domain.Entities;

public class Copy : BaseEntity
{
    #region Properties
    public string Code { get; set; } = null!;
    #endregion

    #region Related Properties
    public int BookID { get; set; }
    public Book? Book { get; set; }
    #endregion
}
