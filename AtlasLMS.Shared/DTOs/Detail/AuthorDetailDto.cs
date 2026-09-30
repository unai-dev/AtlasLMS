using AtlasLMS.Shared.DTOs.Read;

namespace AtlasLMS.Shared.DTOs.Detail;

public class AuthorDetailDto : AuthorReadDto
{
    #region Related Properties
    public List<BookReadDto> Books { get; set; } = new List<BookReadDto>();
    #endregion
}
