using AtlasLMS.Shared.DTOs.Common;
using AtlasLMS.Shared.DTOs.Read;

namespace AtlasLMS.Shared.DTOs.Detail;

public class AuthorDetailDto : BaseDto
{
    public required string FirstName { get; set; }
    public string? LastName { get; set; }

    // Related Properties
    //
    //
    //
    public List<BookReadDto> Books { get; set; } = new List<BookReadDto>();
}
