using System.ComponentModel.DataAnnotations;

namespace AtlasLMS.Application.DTOs.Create;

public class AuthorCreateDto
{
    public required string FirstName { get; set; }

    public string? LastName { get; set; }
}
