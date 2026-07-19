using AtlasLMS.Application.Contracts;
using AtlasLMS.Shared.DTOs.Create;
using AtlasLMS.Shared.Responses;

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
    public async Task<ActionResult<AuthResponse>> Register([FromBody] UserCreateDto dto) =>
        Ok(await _authService.Register(dto));

    [HttpPost]
    [Route("login")]
    public async Task<ActionResult<AuthResponse>> Login([FromBody] UserCreateDto dto) =>
        Ok(await _authService.Login(dto));
}
