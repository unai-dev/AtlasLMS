using Unova.Shared.DTOs.Read;

namespace Unova.Shared.DTOs.Detail;

public class BookDetailDto : BookReadDto
{
    #region Related Properties
    public int AuthorID { get; set; }
    public AuthorReadDto? Author { get; set; }
    public int CategoryID { get; set; }
    public CategoryReadDto? Category { get; set; }

    public List<CopyReadDto> Copies { get; set; } = new List<CopyReadDto>();
    public List<BookingReadDto> Bookings { get; set; } = new List<BookingReadDto>();
    #endregion
}
