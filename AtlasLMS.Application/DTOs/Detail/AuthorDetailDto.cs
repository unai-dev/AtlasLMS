using AtlasLMS.Application.DTOs.Common;
using AtlasLMS.Application.DTOs.Read;

namespace AtlasLMS.Application.DTOs.Detail;

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
