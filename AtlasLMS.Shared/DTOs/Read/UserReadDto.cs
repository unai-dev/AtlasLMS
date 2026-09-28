using AtlasLMS.Shared.DTOs.Common;

namespace AtlasLMS.Shared.DTOs.Read;

public class UserReadDto: BaseDto
{
    public required string UserName { get; set; }
    public required string Email { get; set; }
    public required string CIF { get; set; }
}
