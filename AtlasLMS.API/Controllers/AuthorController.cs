using AtlasLMS.Application.DTOs.Create;
using AtlasLMS.Application.DTOs.Detail;
using AtlasLMS.Application.DTOs.Read;
using AtlasLMS.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AtlasLMS.API.Controllers;

[ApiController]
[Route("api/authors/")]
[Authorize]
public class AuthorController : ControllerBase
{
    private readonly IAuthorService _authorService;

    public AuthorController(IAuthorService authorService)
    {
        _authorService = authorService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AuthorReadDto>>> Get() =>
        Ok(await _authorService.GetAuthorsAsync());

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<AuthorReadDto>> Get([FromRoute] int ID) =>
        Ok(await _authorService.GetAuthorAsync(ID));

    [HttpGet]
    [Route("detail/{id:int}")]
    public async Task<ActionResult<AuthorDetailDto>> GetDetail([FromRoute] int ID) =>
        Ok(await _authorService.GetAuthorDetailAsync(ID));

    [HttpPost]
    public async Task<ActionResult<AuthorReadDto>> Post([FromBody] AuthorCreateDto dto)
    {
        var result = await _authorService.CreateAuthorAsync(dto);
        return CreatedAtAction(nameof(Get), new { ID = result.ID }, result);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int ID)
    {
        await _authorService.DeleteAuthorAsync(ID);
        return NoContent();
    }
}
