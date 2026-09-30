using AtlasLMS.Shared.DTOs.Common;

namespace AtlasLMS.Shared.DTOs.Read;

public class CategoryReadDto : BaseDto
{
    #region Properties
    public required string Name { get; set; }
    #endregion
}
