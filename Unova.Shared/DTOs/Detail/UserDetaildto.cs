using Unova.Shared.DTOs.Read;

namespace Unova.Shared.DTOs.Detail;

public class UserDetailDto : UserReadDto
{
    #region Related Properties
    public int EnterpriseID { get; set; }
    public EnterpriseReadDto? Enterprise { get; set; }
    public List<BookingReadDto> Bookings { get; set; } = new List<BookingReadDto>();
    #endregion
}
