using Unova.App.Contracts.Common;
using Unova.Shared.DTOs.Update;

namespace Unova.App.Contracts;

public interface IEnterpriseService : IUnovaContract<EnterpriseReadDto, EnterpriseDetailDto, EnterpriseCreateDto>
{
    Task<EnterpriseReadDto> UpdateEnterpriseAsync(int ID, EnterpriseUpdateDto dto);
}
