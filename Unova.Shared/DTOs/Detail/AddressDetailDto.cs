using Unova.Shared.DTOs.Read;

namespace Unova.Shared.DTOs.Detail;

public class AddressDetailDto : AddressReadDto
{
    #region Related Properties
    public List<LibraryReadDto> Libraries { get; set; } = new List<LibraryReadDto>();
    #endregion
}