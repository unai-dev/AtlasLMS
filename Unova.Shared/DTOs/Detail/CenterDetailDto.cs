using Unova.Shared.DTOs.Read;

namespace Unova.Shared.DTOs.Detail;

public class CenterDetailDto : CenterReadDto
{
    #region Related Properties
    public int EnterpriseID { get; set; }
    public EnterpriseReadDto? Enterprise { get; set; }

    public List<CopyReadDto> Copies { get; set; } = new List<CopyReadDto>();
    public List<UserReadDto> Users { get; set; } = new List<UserReadDto>();
    #endregion
}
