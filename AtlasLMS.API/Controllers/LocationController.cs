using AtlasLMS.Application.Contracts;
using AtlasLMS.Shared.DTOs.Create;
using AtlasLMS.Shared.DTOs.Detail;
using AtlasLMS.Shared.DTOs.Read;
using AtlasLMS.Shared.DTOs.Update;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AtlasLMS.API.Controllers;

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
        Ok(await _locationService.GetLocationsAsync());

    [HttpGet("{id:int}")]
    public async Task<ActionResult<LocationReadDto>> GetById(int id) =>
        Ok(await _locationService.GetLocationAsync(id));

    [HttpGet("detail/{id:int}")]
    public async Task<ActionResult<LocationDetailDto>> GetDetail(int id) =>
        Ok(await _locationService.GetLocationDetailAsync(id));

    [HttpPost]
    public async Task<ActionResult<LocationReadDto>> Create([FromBody] LocationCreateDto dto)
    {
        var result = await _locationService.CreateLocationAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = result.ID }, result);
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<ActionResult<LocationReadDto>> Put([FromRoute] int ID, [FromBody] LocationUpdateDto dto) =>
        Ok(await _locationService.UpdateLocationAsync(ID, dto));

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _locationService.DeleteLocationAsync(id);
        return NoContent();
    }
}
