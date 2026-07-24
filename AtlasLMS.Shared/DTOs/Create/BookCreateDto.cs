using System.ComponentModel.DataAnnotations;

namespace AtlasLMS.Shared.DTOs.Create;

public class BookCreateDto
{
    [Required]
    [StringLength(55)]
    public string Title { get; set; } = string.Empty;
    [Required]
    [StringLength(13)]
    public string ISBN { get; set; } = string.Empty;
    public int? Stock { get; set; }
    [StringLength(255)]
    public string? Synopsis { get; set; }
    public DateTime PublicationAt { get; set; }

    //Related properties
    //
    //
    //
    public int AuthorID { get; set; }
    public int CategoryID { get; set; }
    public int? LocationID { get; set; }
}
