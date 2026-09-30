using AtlasLMS.Shared.DTOs.Common;

namespace AtlasLMS.Shared.DTOs.Read;

public class AuthorReadDto : BaseDto
{
    #region Properties
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string FullName => $"{FirstName} {LastName}";
    #endregion
}
