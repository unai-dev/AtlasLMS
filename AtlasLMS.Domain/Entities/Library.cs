using System;
using System.Collections.Generic;
using System.Text;

using AtlasLMS.Domain.Entities.Common;

namespace AtlasLMS.Domain.Entities;

public class Library: BaseEntity
{
    #region Properties
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    #endregion

    #region Related Properties
    public int AddressID { get; set; }
    public Address? Address { get; set; }

    public List<Center> Centers { get; set; } = new List<Center>();
    public List<User> Users { get; set; } = new List<User>();
    #endregion
}
