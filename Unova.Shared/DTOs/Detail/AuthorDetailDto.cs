using Unova.Shared.DTOs.Read;

namespace Unova.Shared.DTOs.Detail;

public class AuthorDetailDto : AuthorReadDto
{
    #region Related Properties
    public List<BookReadDto> Books { get; set; } = new List<BookReadDto>();
    #endregion
}
