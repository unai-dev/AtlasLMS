using Unova.Shared.DTOs.Read;

namespace Unova.Shared.DTOs.Detail;

public class CopyDetailDto : CopyReadDto
{
    #region Related Properties
    public int BookID { get; set; }
    public BookReadDto? Book { get; set; }
    public int LocationID { get; set; }
    public LocationReadDto? Location { get; set; }
    #endregion
}
