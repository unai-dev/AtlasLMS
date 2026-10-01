using System.ComponentModel.DataAnnotations;

namespace Unova.Shared.DTOs.Create;

public class AddressCreateDto
{
    #region Properties

    [Required]
    [StringLength(2000)]
    public string MainAddress { get; set; } = string.Empty;

    [StringLength(2000)]
    public string? SecondAddress { get; set; }

    [Required]
    [StringLength(5)]
    public string PostalCode { get; set; } = string.Empty;

    [Required]
    [StringLength(255)]
    public string City { get; set; } = string.Empty;

    [Required]
    [StringLength(255)]
    public string Country { get; set; } = string.Empty;

    #endregion
}