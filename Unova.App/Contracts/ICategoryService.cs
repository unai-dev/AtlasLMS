using Unova.App.Contracts.Common;
using Unova.Shared.DTOs.Create;
using Unova.Shared.DTOs.Detail;
using Unova.Shared.DTOs.Read;

namespace Unova.App.Contracts;

public interface ICategoryService : IUnovaContract<CategoryReadDto, CategoryDetailDto, CategoryCreateDto>
{
}
