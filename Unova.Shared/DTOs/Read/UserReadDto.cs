using Unova.Shared.DTOs.Common;

namespace Unova.Shared.DTOs.Read;

public class UserReadDto : UnovaDTO
{
    public required string UserName { get; set; }
    public required string Email { get; set; }
    public required string CIF { get; set; }
}
