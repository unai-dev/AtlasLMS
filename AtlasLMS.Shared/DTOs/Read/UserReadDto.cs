namespace AtlasLMS.Shared.DTOs.Read;

public class UserReadDto
{
    public required string ID { get; set; }
    public required string UserName { get; set; }
    public required string Email { get; set; }
    public required string CIF { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
