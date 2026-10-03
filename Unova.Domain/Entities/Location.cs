using Unova.Domain.Entities.Common;

namespace Unova.Domain.Entities;

public class Location : UnovaEntity
{
    #region Properties
    public string Aisle { get; set; } = null!;
    public string Shelf { get; set; } = null!;
    public string Column { get; set; } = null!;
    public int Limit { get; set; } = 5;
    #endregion

    #region Related Properties
    public int CenterID { get; set; }
    public Center? Center { get; set; }

    public List<Copy> Copies { get; set; } = new List<Copy>();
    #endregion
}