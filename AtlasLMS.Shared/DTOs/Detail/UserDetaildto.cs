using AtlasLMS.Shared.DTOs.Read;

namespace AtlasLMS.Shared.DTOs.Detail;

public class UserDetailDto : UserReadDto
{
    public List<LoanReadDto> Loans { get; set; } = new List<LoanReadDto>();
    public List<BookingReadDto> Bookings { get; set; } = new List<BookingReadDto>();
}
