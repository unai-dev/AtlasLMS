using AtlasLMS.Application.Contracts;
using AtlasLMS.Shared.DTOs.Create;
using AtlasLMS.Shared.DTOs.Detail;
using AtlasLMS.Shared.DTOs.Read;
using AtlasLMS.Shared.DTOs.Update;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AtlasLMS.API.Controllers;

[ApiController]
[Route("api/books")]
[Authorize]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;

    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BookReadDto>>> Get() =>
        Ok(await _bookService.GetBooksAsync());

    [HttpGet("{id:int}")]
    public async Task<ActionResult<BookReadDto>> GetById([FromRoute] int id) =>
        Ok(await _bookService.GetBook(id));

    [HttpGet("{id:int}/detail")]
    public async Task<ActionResult<BookDetailDto>> GetDetail([FromRoute] int id) =>
        Ok(await _bookService.GetBookDetailAsync(id));

    [HttpPost]
    public async Task<ActionResult<BookReadDto>> Post([FromBody] BookCreateDto dto)
    {
        var result = await _bookService.CreateBookAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = result.ID }, result);
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<ActionResult<BookReadDto>> Put([FromRoute] int ID, [FromBody] BookUpdateDto dto) =>
        Ok(await _bookService.UpdateBookAsync(ID, dto));

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        await _bookService.DeleteBookAsync(id);
        return NoContent();
    }
}
