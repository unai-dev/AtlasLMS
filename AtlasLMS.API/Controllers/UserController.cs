using AtlasLMS.Application.Contracts;
using AtlasLMS.Shared.DTOs.Create;
using AtlasLMS.Shared.DTOs.Read;

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
    [Route("detail/{ID}")]
    public async Task<ActionResult<UserReadDto>> GetDetail([FromRoute] string ID) =>
        Ok(await _userService.GetUserDetailAsync(ID));

    [HttpPost]
    public async Task<ActionResult<UserReadDto>> Post([FromBody] UserCreateDto dto)
    {
        var result = await _userService.CreateUserAsync(dto);
        return CreatedAtAction(nameof(Get), new { ID = result.ID }, result);
    }

    [HttpDelete]
    [Route("{ID}")]
    public async Task<ActionResult> Delete([FromRoute] string ID)
    {
        await _userService.DeleteUserAsync(ID);
        return NoContent();
    }
}
