using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Unova.API.Controllers.Common;

[ApiController]
[Authorize]
public class UnovaController : ControllerBase
{
}
