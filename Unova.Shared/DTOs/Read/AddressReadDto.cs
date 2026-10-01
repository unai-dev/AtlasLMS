using Unova.Shared.DTOs.Common;

namespace Unova.Shared.DTOs.Read;

public class AddressReadDto : BaseDto
{
    #region Properties
    public required string MainAddress { get; set; }
    public string? SecondAddress { get; set; }
    public required string PostalCode { get; set; }
    public required string City { get; set; }
    public required string Country { get; set; }
    #endregion
}