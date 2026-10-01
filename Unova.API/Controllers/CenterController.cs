using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Unova.App.Contracts;
using Unova.Shared.DTOs.Create;
using Unova.Shared.DTOs.Detail;
using Unova.Shared.DTOs.Read;

namespace Unova.API.Controllers;

[ApiController]
[Route("api/centers")]
[Authorize]
public class CenterController : ControllerBase
{
    private readonly ICenterService _centerService;

    public CenterController(ICenterService centerService)
    {
        _centerService = centerService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CenterReadDto>>> Get() =>
        Ok(await _centerService.GetAll());

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<CenterReadDto>> Get([FromRoute] int ID) =>
        Ok(await _centerService.GetByID(ID));

    [HttpGet]
    [Route("detail/{id:int}")]
    public async Task<ActionResult<CenterDetailDto>> GetDetail([FromRoute] int ID) =>
        Ok(await _centerService.GetDetail(ID));

    [HttpPost]
    public async Task<ActionResult<CenterReadDto>> Post([FromBody] CenterCreateDto dto)
    {
        var result = await _centerService.Create(dto);

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
        await _centerService.Delete(ID);
        return NoContent();
    }
}