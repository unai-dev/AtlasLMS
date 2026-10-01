using Microsoft.AspNetCore.Mvc;
using Unova.API.Controllers.Common;
using Unova.App.Contracts;
using Unova.Shared.DTOs.Create;
using Unova.Shared.DTOs.Detail;
using Unova.Shared.DTOs.Read;
using Unova.Shared.DTOs.Update;

namespace Unova.API.Controllers;

[Route("api/authors")]
public class AuthorController : UnovaController
{
    private readonly IAuthorService _authorService;

    public AuthorController(IAuthorService authorService)
    {
        _authorService = authorService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AuthorReadDto>>> Get() =>
        Ok(await _authorService.GetAll());

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<AuthorReadDto>> Get([FromRoute] int ID) =>
        Ok(await _authorService.GetByID(ID));

    [HttpGet]
    [Route("detail/{id:int}")]
    public async Task<ActionResult<AuthorDetailDto>> GetDetail([FromRoute] int ID) =>
        Ok(await _authorService.GetDetail(ID));

    [HttpPost]
    public async Task<ActionResult<AuthorReadDto>> Post([FromBody] AuthorCreateDto dto)
    {
        var result = await _authorService.Create(dto);
        return CreatedAtAction(nameof(Get), new { ID = result.ID }, result);
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<ActionResult<AuthorReadDto>> Put([FromRoute] int ID, [FromBody] AuthorUpdateDto dto) =>
        Ok(await _authorService.UpdateAuthorAsync(ID, dto));

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int ID)
    {
        await _authorService.Delete(ID);
        return NoContent();
    }
}
