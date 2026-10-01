using System.ComponentModel.DataAnnotations;

namespace Unova.Shared.DTOs.Update;

public class AuthorUpdateDto
{
    #region Properties
    [StringLength(55)]
    public string? FirstName { get; set; }
    [StringLength(55)]
    public string? LastName { get; set; }
    #endregion
}
