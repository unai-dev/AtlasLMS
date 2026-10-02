using Microsoft.AspNetCore.Mvc;
using Unova.API.Controllers.Common;
using Unova.App.Contracts;
using Unova.Shared.DTOs.Create;
using Unova.Shared.DTOs.Detail;
using Unova.Shared.DTOs.Read;

namespace Unova.API.Controllers;

[Route("api/users")]
public class UserController : UnovaController
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

    [HttpDelete]
    [Route("{ID}")]
    public async Task<ActionResult> Delete([FromRoute] int ID)
    {
        await _userService.Delete(ID);
        return NoContent();
    }
}
