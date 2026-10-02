using Unova.Shared.DTOs.Read;

namespace Unova.Shared.DTOs.Detail;

public class LocationDetailDto : LocationReadDto
{
    #region Related Properties
    public int CenterID { get; set; }
    public CenterReadDto? Center { get; set; }

    public List<CopyReadDto> Copies { get; set; } = new List<CopyReadDto>();
    #endregion
}
