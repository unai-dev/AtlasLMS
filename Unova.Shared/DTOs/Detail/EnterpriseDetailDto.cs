using Unova.Shared.DTOs.Read;

namespace Unova.Shared.DTOs.Detail;

public class EnterpriseDetailDto : EnterpriseReadDto
{
    #region Related Properties 
    public int AddressID { get; set; }
    public AddressReadDto? Address { get; set; }
    #endregion
}
