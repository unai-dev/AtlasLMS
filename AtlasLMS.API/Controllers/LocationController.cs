using AtlasLMS.Application.Contracts;
using AtlasLMS.Shared.DTOs.Create;
using AtlasLMS.Shared.DTOs.Read;

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

    [HttpGet("aisles")]
    public async Task<ActionResult<IEnumerable<string>>> GetAisles() =>
        Ok(await _locationService.GetAislesAsync());

    [HttpGet("aisles/{aisle}/columns")]
    public async Task<ActionResult<IEnumerable<string>>> GetColumns(string aisle) =>
        Ok(await _locationService.GetColumnsByAisleAsync(aisle));

    [HttpGet("aisles/{aisle}/columns/{column}/shelves")]
    public async Task<ActionResult<IEnumerable<string>>> GetShelves(string aisle, string column) =>
        Ok(await _locationService.GetShelvesAsync(aisle, column));

    [HttpPost]
    public async Task<ActionResult<LocationReadDto>> Create([FromBody] LocationCreateDto dto)
    {
        var result = await _locationService.CreateLocationAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = result.ID }, result);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _locationService.DeleteLocationAsync(id);
        return NoContent();
    }
}
