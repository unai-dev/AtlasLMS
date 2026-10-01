using AtlasLMS.Application.Contracts;
using AtlasLMS.Shared.DTOs.Create;
using AtlasLMS.Shared.DTOs.Detail;
using AtlasLMS.Shared.DTOs.Read;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AtlasLMS.API.Controllers;

[ApiController]
[Route("api/addresses")]
[Authorize]
public class AddressController : ControllerBase
{
    private readonly IAddressService _addressService;

    public AddressController(IAddressService addressService)
    {
        _addressService = addressService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AddressReadDto>>> Get() =>
        Ok(await _addressService.GetAll());

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<AddressReadDto>> Get([FromRoute] int ID) =>
        Ok(await _addressService.GetByID(ID));

    [HttpGet]
    [Route("detail/{id:int}")]
    public async Task<ActionResult<AddressDetailDto>> GetDetail([FromRoute] int ID) =>
        Ok(await _addressService.GetDetail(ID));

    [HttpPost]
    public async Task<ActionResult<AddressReadDto>> Post([FromBody] AddressCreateDto dto)
    {
        var result = await _addressService.Create(dto);

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
        await _addressService.Delete(ID);
        return NoContent();
    }
}