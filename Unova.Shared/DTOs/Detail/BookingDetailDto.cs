using AtlasLMS.Shared.DTOs.Read;

namespace AtlasLMS.Shared.DTOs.Detail;

public class BookingDetailDto : BookingReadDto
{
    #region Related Properties
    public int BookID { get; set; }
    public BookReadDto? Book { get; set; }
    public int UserID { get; set; }
    public UserReadDto? User { get; set; }
    #endregion
}
