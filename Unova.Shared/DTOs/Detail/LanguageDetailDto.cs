using Unova.Shared.DTOs.Read;

namespace Unova.Shared.DTOs.Detail;

public class LanguageDetailDto : LanguageReadDto
{
    #region Related Properties
    public List<UserReadDto> Users { get; set; } = new List<UserReadDto>();
    #endregion
}
