using AtlasLMS.Shared.DTOs.Read;

namespace AtlasLMS.Shared.DTOs.Detail;

public class UserDetailDto : UserReadDto
{
    //Related properties
    //
    //
    //
    public List<BookingReadDto> Bookings { get; set; } = new List<BookingReadDto>();
}
