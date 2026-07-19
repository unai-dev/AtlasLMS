namespace AtlasLMS.Shared.DTOs.Update;

public class AuthorUpdateDto
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
