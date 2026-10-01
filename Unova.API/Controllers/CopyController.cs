using Microsoft.AspNetCore.Mvc;
using Unova.API.Controllers.Common;
using Unova.App.Contracts;
using Unova.Shared.DTOs.Create;
using Unova.Shared.DTOs.Detail;
using Unova.Shared.DTOs.Read;

namespace Unova.API.Controllers;

[Route("api/copies")]
public class CopyController : UnovaController
{
    private readonly ICopyService _copyService;

    public CopyController(ICopyService copyService)
    {
        _copyService = copyService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CopyReadDto>>> Get() =>
        Ok(await _copyService.GetAll());

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<CopyReadDto>> Get([FromRoute] int ID) =>
        Ok(await _copyService.GetByID(ID));

    [HttpGet]
    [Route("detail/{id:int}")]
    public async Task<ActionResult<CopyDetailDto>> GetDetail([FromRoute] int ID) =>
        Ok(await _copyService.GetDetail(ID));

    [HttpPost]
    public async Task<ActionResult<CopyReadDto>> Post([FromBody] CopyCreateDto dto)
    {
        var result = await _copyService.Create(dto);

        return CreatedAtAction(
            nameof(Get),
            new { ID = result.ID },
            result
        );
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int ID)
    {
        await _copyService.Delete(ID);
        return NoContent();
    }
}