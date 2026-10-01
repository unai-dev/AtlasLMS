using Unova.Shared.DTOs.Read;

namespace Unova.Shared.DTOs.Detail;

public class LibraryDetailDto : LibraryReadDto
{
    #region Related Properties 
    public int AddressID { get; set; }
    public AddressReadDto? Address { get; set; }
    #endregion
}
