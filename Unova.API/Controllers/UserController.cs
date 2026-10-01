using Microsoft.AspNetCore.Mvc;

using Unova.App.Contracts;
using Unova.Shared.DTOs.Create;
using Unova.Shared.DTOs.Detail;
using Unova.Shared.DTOs.Read;
using Unova.Shared.DTOs.Update;

namespace Unova.API.Controllers;

[ApiController]
[Route("api/users")]
//[Authorize]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserReadDto>>> Get() =>
        Ok(await _userService.GetAll());

    [HttpGet]
    [Route("me")]
    public async Task<ActionResult<UserReadDto>> GetMe() =>
        Ok(await _userService.GetMe());

    [HttpGet]
    [Route("{ID}")]
    public async Task<ActionResult<UserReadDto>> Get([FromRoute] int ID) =>
        Ok(await _userService.GetByID(ID));

    [HttpGet]
    [Route("detail/{ID}")]
    public async Task<ActionResult<UserDetailDto>> GetDetail([FromRoute] int ID) =>
        Ok(await _userService.GetDetail(ID));

    [HttpPost]
    public async Task<ActionResult<UserReadDto>> Post([FromBody] UserCreateDto dto)
    {
        var result = await _userService.Create(dto);
        return CreatedAtAction(nameof(Get), new { ID = result.ID }, result);
    }

    [HttpPut]
    [Route("{ID}")]
    public async Task<ActionResult<UserReadDto>> Put([FromRoute] int ID, [FromBody] UserUpdateDto dto) =>
        Ok(await _userService.UpdateUserAsync(ID, dto));

    [HttpDelete]
    [Route("{ID}")]
    public async Task<ActionResult> Delete([FromRoute] int ID)
    {
        await _userService.Delete(ID);
        return NoContent();
    }
}
