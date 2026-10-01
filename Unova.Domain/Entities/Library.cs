using Unova.Domain.Entities.Common;

namespace Unova.Domain.Entities;

public class Library : BaseEntity
{
    #region Properties
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public string NIF { get; set; } = null!;
    #endregion

    #region Related Properties
    public int AddressID { get; set; }
    public Address? Address { get; set; }

    public List<Center> Centers { get; set; } = new List<Center>();
    public List<User> Users { get; set; } = new List<User>();
    #endregion
}
