using System.ComponentModel.DataAnnotations;

namespace AtlasLMS.Shared.DTOs.Update;

public class AuthorUpdateDto
{
    [StringLength(55)]
    public string? FirstName { get; set; }
    [StringLength(55)]
    public string? LastName { get; set; }
}
