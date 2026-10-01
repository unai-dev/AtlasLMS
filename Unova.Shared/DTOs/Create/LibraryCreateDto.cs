using System.ComponentModel.DataAnnotations;

namespace Unova.Shared.DTOs.Create;

public class LibraryCreateDto
{
    #region Properties 
    [Required]
    [StringLength(255)]
    public string Name { get; set; } = string.Empty;

    [StringLength(2000)]
    public string? Description { get; set; }

    [Required]
    [StringLength(15)]
    public string NIF { get; set; } = string.Empty;
    #endregion

    #region Related Properties 
    [Required]
    public int AddressID { get; set; }
    #endregion
}
