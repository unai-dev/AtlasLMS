using System.ComponentModel.DataAnnotations;

namespace Unova.Shared.DTOs.Update;

public class AddressUpdateDto
{
    #region Properties

    [StringLength(2000)]
    public string? MainAddress { get; set; }

    [StringLength(2000)]
    public string? SecondAddress { get; set; }

    [StringLength(5)]
    public string? PostalCode { get; set; }

    [StringLength(255)]
    public string? City { get; set; }

    [StringLength(255)]
    public string? Country { get; set; }

    #endregion
}