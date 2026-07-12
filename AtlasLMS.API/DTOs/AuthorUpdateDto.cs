using System.ComponentModel.DataAnnotations;

namespace AtlasLMS.API.DTOs;

public class AuthorUpdateDto
{
    public int ID { get; set; }

    [Required]
    [StringLength(55, ErrorMessage = "Name length can't be more than 55.", MinimumLength = 3)]
    public string FirstName { get; set; } = string.Empty;

    [StringLength(55, ErrorMessage = "LastName length can't be more than 55.", MinimumLength = 3)]
    public string LastName { get; set; } = string.Empty;

    public DateTime? UpdatedAt { get; set; } = DateTime.Now;
}
