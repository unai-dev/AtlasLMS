namespace AtlasLMS.Shared.DTOs.Create;

public class UserCreateDto
{
    public required string Email { get; set; }
    public string? UserName { get; set; }
    public required string Password { get; set; }
}
