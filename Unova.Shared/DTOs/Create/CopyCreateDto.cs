namespace Unova.Shared.DTOs.Create;

public class CopyCreateDto
{
    #region Properties
    [Required]
    [StringLength(50)]
    public string Code { get; set; } = string.Empty;
    #endregion

    #region Related properties
    public int BookID { get; set; }
    #endregion
}
