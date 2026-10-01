using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Unova.App.Contracts;
using Unova.Shared.DTOs.Create;
using Unova.Shared.DTOs.Detail;
using Unova.Shared.DTOs.Read;
using Unova.Shared.DTOs.Update;

namespace Unova.API.Controllers;

[ApiController]
[Route("api/locations")]
[Authorize]
public class LocationController : ControllerBase
{
    private readonly ILocationService _locationService;

    public LocationController(ILocationService locationService)
    {
        _locationService = locationService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<LocationReadDto>>> GetAll() =>
        Ok(await _locationService.GetAll());

    [HttpGet("{id:int}")]
    public async Task<ActionResult<LocationReadDto>> GetById(int id) =>
        Ok(await _locationService.GetByID(id));

    [HttpGet("detail/{id:int}")]
    public async Task<ActionResult<LocationDetailDto>> GetDetail(int id) =>
        Ok(await _locationService.GetDetail(id));

    [HttpPost]
    public async Task<ActionResult<LocationReadDto>> Create([FromBody] LocationCreateDto dto)
    {
        var result = await _locationService.Create(dto);
        return CreatedAtAction(nameof(GetById), new { id = result.ID }, result);
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<ActionResult<LocationReadDto>> Put([FromRoute] int ID, [FromBody] LocationUpdateDto dto) =>
        Ok(await _locationService.UpdateLocationAsync(ID, dto));

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _locationService.Delete(id);
        return NoContent();
    }
}
