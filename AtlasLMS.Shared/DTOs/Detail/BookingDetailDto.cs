using AtlasLMS.Shared.DTOs.Read;

namespace AtlasLMS.Shared.DTOs.Detail;

public class BookingDetailDto : BookingReadDto
{
    // Related Properties
    //
    //
    //
    public int BookID { get; set; }
    public BookReadDto? Book { get; set; }
    public required string UserID { get; set; }
    public UserReadDto? User { get; set; }
}
