using Unova.Domain.Entities.Common;

namespace Unova.Domain.Entities;

public class Address : UnovaEntity
{
    #region Properties
    public string MainAddress { get; set; } = null!;
    public string? SecondAddress { get; set; }
    public string PostalCode { get; set; } = null!;
    public string City { get; set; } = null!;
    public string Country { get; set; } = null!;
    #endregion

    #region Related Properties
    public List<Enterprise> Enterprises { get; set; } = new List<Enterprise>();
    #endregion
}
