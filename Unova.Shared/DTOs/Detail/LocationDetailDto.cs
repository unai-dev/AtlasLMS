using Unova.Shared.DTOs.Read;

namespace Unova.Shared.DTOs.Detail;

public class LocationDetailDto : LocationReadDto
{
    #region Related Properties
    public List<BookReadDto> Books { get; set; } = new List<BookReadDto>();
    #endregion
}
