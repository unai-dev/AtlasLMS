using AtlasLMS.Application.Contracts.Common;
using AtlasLMS.Shared.DTOs.Create;
using AtlasLMS.Shared.DTOs.Detail;
using AtlasLMS.Shared.DTOs.Read;

namespace AtlasLMS.Application.Contracts;

public interface ICenterService: IAtlasContract<CenterReadDto, CenterDetailDto, CenterCreateDto>
{
}
