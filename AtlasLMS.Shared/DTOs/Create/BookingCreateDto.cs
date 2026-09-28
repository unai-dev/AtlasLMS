using System.ComponentModel.DataAnnotations;

namespace AtlasLMS.Shared.DTOs.Create;

public class BookingCreateDto
{
    [Required]
    public DateTime StartTime { get; set; } = DateTime.UtcNow;

    //Related properties
    //
    //
    //
    public int UserID { get; set; }
    public int BookID { get; set; }
}
