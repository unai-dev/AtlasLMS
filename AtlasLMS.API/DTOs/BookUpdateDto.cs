using System.ComponentModel.DataAnnotations;

namespace AtlasLMS.API.DTOs;

public class BookUpdateDto
{
    public int ID { get; set; }

    [Required]
    [StringLength(55, ErrorMessage = "Title length can't be more than 55.", MinimumLength = 3)]
    public string Title { get; set; } = string.Empty;

    [Required]
    [StringLength(13, ErrorMessage = "The ISBN must be 13 digits long.")]
    public string ISBN { get; set; } = string.Empty;

    [StringLength(250)]
    public string Synopsis { get; set; } = string.Empty;

    [Required]
    public DateTime PublicationAt { get; set; }

    [Required]
    public int AuthorID { get; set; }

    [Required]
    public int CategoryID { get; set; }

    public DateTime? UpdatedAt { get; set; } = DateTime.Now;
}
