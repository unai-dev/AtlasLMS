using AtlasLMS.Shared.DTOs.Common;

namespace AtlasLMS.Shared.DTOs.Read;

public class AuthorReadDto : BaseDto
{
    public required string FirstName { get; set; }
    public string? LastName { get; set; }
}
