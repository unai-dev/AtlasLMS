using Unova.Shared.DTOs.Common;

namespace Unova.Shared.DTOs.Read;

public class AuthorReadDto : UnovaDTO
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string FullName => $"{FirstName} {LastName}";
}
