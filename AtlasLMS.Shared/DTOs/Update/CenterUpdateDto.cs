using System.ComponentModel.DataAnnotations;

namespace AtlasLMS.Shared.DTOs.Update;

public class CenterUpdateDto
{
    #region Properties
    [StringLength(55)]
    public string? Name { get; set; }

    [StringLength(2000)]
    public string? Description { get; set; }

    [StringLength(3)]
    public string? Abbreviation { get; set; }
    #endregion

    #region Related Properties
    public int? LibraryID { get; set; }
    #endregion
}
