using AtlasLMS.Application.Contracts;
using AtlasLMS.Shared.DTOs.Create;
using AtlasLMS.Shared.DTOs.Read;
using AtlasLMS.Shared.DTOs.Update;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AtlasLMS.API.Controllers;

[ApiController]
[Route("api/users")]
[Authorize]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserReadDto>>> Get() =>
        Ok(await _userService.GetUsersAsync());

    [HttpGet]
    [Route("{ID}")]
    public async Task<ActionResult<UserReadDto>> Get([FromRoute] string ID) =>
        Ok(await _userService.GetUserAsync(ID));

    [HttpGet]
    [Route("loan/{ID}")]
    public async Task<ActionResult<UserReadDto>> GetLoans([FromRoute] string ID) =>
        Ok(await _userService.GetUserLoansAsync(ID));

    [HttpGet]
    [Route("booking/{ID}")]
    public async Task<ActionResult<UserReadDto>> GetBookings([FromRoute] string ID) =>
        Ok(await _userService.GetUserBookingsAsync(ID));

    [HttpPost]
    public async Task<ActionResult<UserReadDto>> Post([FromBody] UserCreateDto dto)
    {
        var result = await _userService.CreateUserAsync(dto);
        return CreatedAtAction(nameof(Get), new { ID = result.ID }, result);
    }

    [HttpPut]
    [Route("{ID}")]
    public async Task<ActionResult<UserReadDto>> Put([FromRoute] string ID, [FromBody] UserUpdateDto dto) =>
        Ok(await _userService.UpdateUserAsync(ID, dto));

    [HttpDelete]
    [Route("{ID}")]
    public async Task<ActionResult> Delete([FromRoute] string ID)
    {
        await _userService.DeleteUserAsync(ID);
        return NoContent();
    }
}
