using Unova.Domain.Entities.Common;

namespace Unova.Domain.Entities;

public class Center : UnovaEntity
{
    #region Properties
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public string Abbreviation { get; set; } = null!;
    #endregion

    #region Related Properties
    public int EnterpriseID { get; set; }
    public Enterprise? Enterprise { get; set; }

    public List<Location> Locations { get; set; } = new List<Location>();
    public List<User> Users { get; set; } = new List<User>();
    #endregion
}
