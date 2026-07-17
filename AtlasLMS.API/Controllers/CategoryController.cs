using AtlasLMS.Application.Contracts;
using AtlasLMS.Shared.DTOs.Create;
using AtlasLMS.Shared.DTOs.Read;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AtlasLMS.API.Controllers;

[ApiController]
[Route("api/categories/")]
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
        Ok(await _categoryService.GetCategoriesAsync());

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<CategoryReadDto>> Get([FromRoute] int ID) =>
        Ok(await _categoryService.GetCategoryAsync(ID));

    [HttpPost]
    public async Task<ActionResult<CategoryReadDto>> Post([FromBody] CategoryCreateDto dto)
    {
        var result = await _categoryService.CreateCategoryAsync(dto);
        return CreatedAtAction(nameof(Get), new { ID = result.ID }, result);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int ID)
    {
        await _categoryService.DeleteCategoryAsync(ID);
        return NoContent();
    }
}
