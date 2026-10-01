using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Unova.App.Contracts;
using Unova.Shared.DTOs.Create;
using Unova.Shared.DTOs.Detail;
using Unova.Shared.DTOs.Read;

namespace Unova.API.Controllers;

[ApiController]
[Route("api/categories")]
[Authorize]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryReadDto>>> Get() =>
        Ok(await _categoryService.GetAll());

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<CategoryReadDto>> Get([FromRoute] int ID) =>
        Ok(await _categoryService.GetByID(ID));

    [HttpGet]
    [Route("detail/{id:int}")]
    public async Task<ActionResult<CategoryDetailDto>> GetDetail([FromRoute] int ID) =>
        Ok(await _categoryService.GetDetail(ID));

    [HttpPost]
    public async Task<ActionResult<CategoryReadDto>> Post([FromBody] CategoryCreateDto dto)
    {
        var result = await _categoryService.Create(dto);
        return CreatedAtAction(nameof(Get), new { ID = result.ID }, result);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int ID)
    {
        await _categoryService.Delete(ID);
        return NoContent();
    }
}
