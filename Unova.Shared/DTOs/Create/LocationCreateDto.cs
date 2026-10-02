namespace Unova.Shared.DTOs.Create;

public class LocationCreateDto
{
    #region Properties
    [Required]
    [StringLength(5)]
    public string Aisle { get; set; } = string.Empty;
    [Required]
    [StringLength(5)]
    public string Shelf { get; set; } = string.Empty;
    [Required]
    [StringLength(5)]
    public string Column { get; set; } = string.Empty;
    public int LimitOfBooks { get; set; }
    #endregion

    #region Related properties
    public int CenterID { get; set; }
    #endregion
}
