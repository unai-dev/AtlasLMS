namespace AtlasLMS.Shared.DTOs.Update;

public class CategoryUpdateDto
{
    public string? Name { get; set; }
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
