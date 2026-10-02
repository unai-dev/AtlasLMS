using Unova.App.Contracts.Common;
using Unova.Shared.DTOs.Update;

namespace Unova.App.Contracts;

public interface ILanguageService : IUnovaContract<LanguageReadDto, LanguageDetailDto, LanguageCreateDto>
{
    Task<LanguageReadDto> UpdateLanguageAsync(int ID, LanguageUpdateDto dto);
}
