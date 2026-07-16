using AtlasLMS.Application.DTOs.Common;

namespace AtlasLMS.Application.DTOs.Read;

public class CategoryReadDto : BaseDto
{
    public required string Name { get; set; }
}
