using System.ComponentModel.DataAnnotations;

namespace Unova.Shared.DTOs.Update;

public class LibraryUpdateDto
{
    #region Properties 
    [StringLength(255)]
    public string? Name { get; set; }

    [StringLength(2000)]
    public string? Description { get; set; }

    [StringLength(15)]
    public string? NIF { get; set; }
    #endregion

    #region Related Properties 
    public int? AddressID { get; set; }
    #endregion
}
