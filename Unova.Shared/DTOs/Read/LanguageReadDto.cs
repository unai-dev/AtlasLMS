using Unova.Shared.DTOs.Common;

namespace Unova.Shared.DTOs.Read;

public class LanguageReadDto : BaseDto
{
    public required string Iso639Code { get; set; }
    public required string Name { get; set; }
}
