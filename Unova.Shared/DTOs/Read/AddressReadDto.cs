using AtlasLMS.Shared.DTOs.Common;

namespace AtlasLMS.Shared.DTOs.Read;

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