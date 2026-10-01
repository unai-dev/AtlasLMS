using Unova.Shared.DTOs.Read;

namespace Unova.Shared.DTOs.Detail;

public class BookDetailDto : BookReadDto
{
    #region Related Properties
    public int AuthorID { get; set; }
    public AuthorReadDto? Author { get; set; }
    public int CategoryID { get; set; }
    public required string CategoryName { get; set; }
    public CategoryReadDto? Category { get; set; }
    public int LocationID { get; set; }
    public LocationReadDto? Location { get; set; }
    #endregion
}
