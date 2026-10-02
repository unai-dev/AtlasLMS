using Unova.Shared.DTOs.Read;

namespace Unova.Shared.DTOs.Detail;

public class UserDetailDto : UserReadDto
{
    #region Related Properties
    public int EnterpriseID { get; set; }
    public EnterpriseReadDto? Enterprise { get; set; }
    public int LanguageID { get; set; }
    public LanguageReadDto? Language { get; set; }
    public int CenterID { get; set; }
    public CenterReadDto? Center { get; set; }
    public List<BookingReadDto> Bookings { get; set; } = new List<BookingReadDto>();
    #endregion
}
