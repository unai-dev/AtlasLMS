using Unova.Shared.DTOs.Read;

namespace Unova.Shared.DTOs.Detail;

public class CenterDetailDto : CenterReadDto
{
    #region Related Properties
    public int LibraryID { get; set; }
    public LibraryReadDto? Library { get; set; }

    public List<BookReadDto> Books { get; set; } = new List<BookReadDto>();
    #endregion
}
