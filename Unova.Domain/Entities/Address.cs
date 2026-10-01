using Unova.Domain.Entities.Common;

namespace Unova.Domain.Entities;

public class Address : BaseEntity
{
    #region Properties
    public string MainAddress { get; set; } = null!;
    public string? SecondAddress { get; set; }
    public string PostalCode { get; set; } = null!;
    public string City { get; set; } = null!;
    public string Country { get; set; } = null!;
    #endregion

    #region Related Properties
    public List<Library> Libraries { get; set; } = new List<Library>();
    #endregion
}
