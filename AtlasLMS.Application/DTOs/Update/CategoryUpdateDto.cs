using System;
using System.ComponentModel.DataAnnotations;

namespace AtlasLMS.Application.DTOs.Update;

public class CategoryUpdateDto
{
    public required string Name { get; set; }
    public DateTime UpdatedAt { get; set; }
}
