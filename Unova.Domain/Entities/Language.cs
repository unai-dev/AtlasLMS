using Unova.Domain.Entities.Common;

namespace Unova.Domain.Entities;

public class Language : UnovaEntity
{
    #region Properties
    public string Iso639Code { get; set; } = null!;
    public string Name { get; set; } = null!;
    #endregion

    #region Related Properties
    public List<User> Users { get; set; } = new List<User>();
    #endregion
}
