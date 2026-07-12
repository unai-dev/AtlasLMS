namespace AtlasLMS.API.DTOs;

public class AuthorDetailDto : BaseDto
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public List<BookReadDto> Books { get; set; } = new List<BookReadDto>();
}
