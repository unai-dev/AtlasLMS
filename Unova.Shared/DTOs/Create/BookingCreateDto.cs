namespace Unova.Shared.DTOs.Create;

public class BookingCreateDto
{
    #region Properties
    public DateTime StartTime { get; set; } = DateTime.UtcNow;
    #endregion

    #region Related properties
    public int UserID { get; set; }
    public int BookID { get; set; }
    #endregion
}
