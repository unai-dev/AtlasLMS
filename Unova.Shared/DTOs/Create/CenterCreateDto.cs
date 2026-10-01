using System.ComponentModel.DataAnnotations;

namespace Unova.Shared.DTOs.Create;

public class CenterCreateDto
{
    #region Properties
    [Required]
    [StringLength(55)]
    public string Name { get; set; } = string.Empty;

    [StringLength(2000)]
    public string? Description { get; set; }

    [Required]
    [StringLength(3)]
    public string Abbreviation { get; set; } = string.Empty;
    #endregion

    #region Related Properties
    public int LibraryID { get; set; }
    #endregion
}
