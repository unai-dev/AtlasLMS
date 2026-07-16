using System;
using System.ComponentModel.DataAnnotations;

namespace AtlasLMS.Application.DTOs.Update;

public class AuthorUpdateDto
{
    public required string FirstName { get; set; }

    public string? LastName { get; set; }

    public DateTime UpdatedAt { get; set; }
}
