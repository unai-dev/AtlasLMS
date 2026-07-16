using AtlasLMS.Application.DTOs.Common;

namespace AtlasLMS.Application.DTOs.Read;

public class AuthorReadDto : BaseDto
{
    public required string FirstName { get; set; }
    public string? LastName { get; set; }
}
