using System.ComponentModel.DataAnnotations;

namespace AtlasLMS.Shared.DTOs.Create;

public class BookingCreateDto
{
    [Required]
    public DateTime StartTime { get; set; }

    //Related properties
    //
    //
    //
    [Required]
    public string UserID { get; set; } = string.Empty;
    public int BookID { get; set; }
}
