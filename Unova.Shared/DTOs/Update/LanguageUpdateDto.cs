namespace Unova.Shared.DTOs.Update;

public class LanguageUpdateDto
{
    #region Properties
    [StringLength(5)]
    public string? Iso639Code { get; set; }
    [StringLength(55)]
    public string? Name { get; set; }
    #endregion
}
