using Microsoft.AspNetCore.Mvc;
using Unova.API.Controllers.Common;
using Unova.App.Contracts;
using Unova.Shared.DTOs.Create;
using Unova.Shared.DTOs.Detail;
using Unova.Shared.DTOs.Read;
using Unova.Shared.DTOs.Update;

namespace Unova.API.Controllers;

[Route("api/languages")]
public class LanguageController : UnovaController
{
    private readonly ILanguageService _languageService;

    public LanguageController(ILanguageService languageService)
    {
        _languageService = languageService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<LanguageReadDto>>> GetAll() =>
        Ok(await _languageService.GetAll());

    [HttpGet("{id:int}")]
    public async Task<ActionResult<LanguageReadDto>> GetById(int id) =>
        Ok(await _languageService.GetByID(id));

    [HttpGet("detail/{id:int}")]
    public async Task<ActionResult<LanguageDetailDto>> GetDetail(int id) =>
        Ok(await _languageService.GetDetail(id));

    [HttpPost]
    public async Task<ActionResult<LanguageReadDto>> Create([FromBody] LanguageCreateDto dto)
    {
        var result = await _languageService.Create(dto);
        return CreatedAtAction(nameof(GetById), new { id = result.ID }, result);
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<ActionResult<LanguageReadDto>> Put([FromRoute] int ID, [FromBody] LanguageUpdateDto dto) =>
        Ok(await _languageService.UpdateLanguageAsync(ID, dto));

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _languageService.Delete(id);
        return NoContent();
    }
}
