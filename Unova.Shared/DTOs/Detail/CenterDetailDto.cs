using AtlasLMS.Shared.DTOs.Read;

namespace AtlasLMS.Shared.DTOs.Detail;

public class CenterDetailDto: CenterReadDto
{
    #region Related Properties
    public int LibraryID { get; set; }
    public LibraryReadDto? Library { get; set; }

    public List<BookReadDto> Books { get; set; } = new List<BookReadDto>();
    #endregion
}
