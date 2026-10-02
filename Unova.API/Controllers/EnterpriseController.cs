using Microsoft.AspNetCore.Mvc;
using Unova.API.Controllers.Common;
using Unova.App.Contracts;
using Unova.Shared.DTOs.Create;
using Unova.Shared.DTOs.Detail;
using Unova.Shared.DTOs.Read;

namespace Unova.API.Controllers;

[Route("api/enterprises")]
public class EnterpriseController : UnovaController
{
    private readonly IEnterpriseService _enterpriseService;

    public EnterpriseController(IEnterpriseService enterpriseService)
    {
        _enterpriseService = enterpriseService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<EnterpriseReadDto>>> Get() =>
        Ok(await _enterpriseService.GetAll());

    [HttpGet("{id:int}")]
    public async Task<ActionResult<EnterpriseReadDto>> GetById([FromRoute] int id) =>
        Ok(await _enterpriseService.GetByID(id));

    [HttpGet("detail/{id:int}")]
    public async Task<ActionResult<EnterpriseDetailDto>> GetDetail([FromRoute] int id) =>
        Ok(await _enterpriseService.GetDetail(id));

    [HttpPost]
    public async Task<ActionResult<EnterpriseReadDto>> Post([FromBody] EnterpriseCreateDto dto)
    {
        var result = await _enterpriseService.Create(dto);
        return CreatedAtAction(nameof(GetById), new { id = result.ID }, result);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        await _enterpriseService.Delete(id);
        return NoContent();
    }
}
