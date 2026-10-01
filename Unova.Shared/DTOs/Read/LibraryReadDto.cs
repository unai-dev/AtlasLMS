using Unova.Shared.DTOs.Common;

namespace Unova.Shared.DTOs.Read;

public class LibraryReadDto : BaseDto
{
    #region Properties 
    public required string Name { get; set; }
    public string? Description { get; set; }
    public required string NIF { get; set; }
    #endregion
}
