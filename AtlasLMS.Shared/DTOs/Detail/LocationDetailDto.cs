using AtlasLMS.Shared.DTOs.Read;

namespace AtlasLMS.Shared.DTOs.Detail;

public class LocationDetailDto : LocationReadDto
{
    //Related Properties
    //
    //
    //
    public List<BookingReadDto> Books { get; set; } = new List<BookingReadDto>();
}
