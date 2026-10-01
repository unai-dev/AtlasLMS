
using AtlasLMS.Shared.DTOs.Read;

namespace AtlasLMS.Shared.DTOs.Detail;

public class LibraryDetailDto: LibraryReadDto
{
    #region Related Properties 
    public int AddressID { get; set; } 
    public AddressReadDto? Address { get; set; } 
    #endregion
}
