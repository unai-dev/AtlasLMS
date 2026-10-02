namespace Unova.Shared.DTOs.Create;

public class LanguageCreateDto
{
    #region Properties
    [Required]
    [StringLength(5)]
    public string Iso639Code { get; set; } = string.Empty;
    [Required]
    [StringLength(55)]
    public string Name { get; set; } = string.Empty;
    #endregion
}
