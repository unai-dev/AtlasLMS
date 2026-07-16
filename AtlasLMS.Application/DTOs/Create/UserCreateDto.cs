using System.ComponentModel.DataAnnotations;

namespace AtlasLMS.Application.DTOs.Create;

public class UserCreateDto
{
    public required string Email { get; set; }
    public string? UserName { get; set; }
    public string? Password { get; set; }
}
