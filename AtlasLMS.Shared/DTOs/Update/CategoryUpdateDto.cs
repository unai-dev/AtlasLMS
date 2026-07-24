using System.ComponentModel.DataAnnotations;

namespace AtlasLMS.Shared.DTOs.Update;

public class CategoryUpdateDto
{
    [StringLength(55)]
    public string? Name { get; set; }
}
