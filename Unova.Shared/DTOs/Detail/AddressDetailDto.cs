using Unova.Shared.DTOs.Read;

namespace Unova.Shared.DTOs.Detail;

public class AddressDetailDto : AddressReadDto
{
    #region Related Properties
    public List<EnterpriseReadDto> Enterprises { get; set; } = new List<EnterpriseReadDto>();
    #endregion
}