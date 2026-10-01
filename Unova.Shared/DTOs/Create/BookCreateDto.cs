using System.ComponentModel.DataAnnotations;

namespace Unova.Shared.DTOs.Create;

public class BookCreateDto
{
    #region Properties
    [Required]
    [StringLength(55)]
    public string Title { get; set; } = string.Empty;
    [Required]
    [StringLength(13)]
    public string ISBN { get; set; } = string.Empty;
    public int Stock { get; set; }
    [StringLength(255)]
    public string? Synopsis { get; set; }
    public DateTime PublicationAt { get; set; } = DateTime.UtcNow;
    #endregion

    #region Related properties
    public int AuthorID { get; set; }
    public int CategoryID { get; set; }
    public int? LocationID { get; set; }
    #endregion
}
