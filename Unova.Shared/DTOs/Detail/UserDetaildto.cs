using Unova.Shared.DTOs.Read;

namespace Unova.Shared.DTOs.Detail;

public class UserDetailDto : UserReadDto
{
    #region Related Properties
    public int LibraryID { get; set; }
    public LibraryReadDto? Library { get; set; }
    public List<BookingReadDto> Bookings { get; set; } = new List<BookingReadDto>();
    #endregion
}
