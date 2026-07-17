using AtlasLMS.Application.Contracts;
using AtlasLMS.Shared.DTOs;
using AtlasLMS.Shared.DTOs.Create;

using Microsoft.AspNetCore.Mvc;

namespace AtlasLMS.API.Controllers;

[ApiController]
[Route("api/auth/")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost]
    [Route("register")]
    public async Task<ActionResult<AuthResponseDto>> Register([FromBody] UserCreateDto dto) =>
        Ok(await _authService.Register(dto));

    [HttpPost]
    [Route("login")]
    public async Task<ActionResult<AuthResponseDto>> Login([FromBody] UserCreateDto dto) =>
        Ok(await _authService.Login(dto));
}
