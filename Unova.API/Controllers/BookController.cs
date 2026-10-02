using Microsoft.AspNetCore.Mvc;
using Unova.API.Controllers.Common;
using Unova.App.Contracts;
using Unova.Shared.DTOs.Create;
using Unova.Shared.DTOs.Detail;
using Unova.Shared.DTOs.Read;

namespace Unova.API.Controllers;

[Route("api/books")]
public class BookController : UnovaController
{
    private readonly IBookService _bookService;

    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BookReadDto>>> Get() =>
        Ok(await _bookService.GetAll());

    [HttpGet("{id:int}")]
    public async Task<ActionResult<BookReadDto>> GetById([FromRoute] int id) =>
        Ok(await _bookService.GetByID(id));

    [HttpGet("detail/{id:int}")]
    public async Task<ActionResult<BookDetailDto>> GetDetail([FromRoute] int id) =>
        Ok(await _bookService.GetDetail(id));

    [HttpPost]
    public async Task<ActionResult<BookReadDto>> Post([FromBody] BookCreateDto dto)
    {
        var result = await _bookService.Create(dto);
        return CreatedAtAction(nameof(GetById), new { id = result.ID }, result);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        await _bookService.Delete(id);
        return NoContent();
    }
}
