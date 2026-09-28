using AtlasLMS.Shared.DTOs.Common;

namespace AtlasLMS.Shared.DTOs.Read;

public class CenterReadDto: BaseDto
{
    #region Properties 
    public required string Name { get; set; } 
    public string? Description { get; set; } 
    public required string Abbreviation { get; set; } 
    #endregion
}
