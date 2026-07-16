using AtlasLMS.Application.DTOs.Create;
using AtlasLMS.Application.DTOs.Read;
using AtlasLMS.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AtlasLMS.API.Controllers;

[ApiController]
[Route("api/loans")]
[Authorize]
public class LoanController : ControllerBase
{
    private readonly ILoanService _loanService;

    public LoanController(ILoanService loanService)
    {
        _loanService = loanService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<LoanReadDto>>> Get([FromQuery] DateTime? limitDueDate)
    {
        if (limitDueDate.HasValue)
        {
            return Ok(await _loanService.GetLoansByDueDateAsync(limitDueDate));
        }

        return Ok(await _loanService.GetLoansAsync());
    }

    [HttpGet]
    [Route("users/{userID}")]
    public async Task<ActionResult<IEnumerable<LoanReadDto>>> GetByUser([FromRoute] string userID) =>
        Ok(await _loanService.GetLoansByUserAsync(userID));

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<LoanReadDto>> Get([FromRoute] int id) =>
        Ok(await _loanService.GetLoanAsync(id));

    [HttpGet]
    [Route("books/{bookID:int}")]
    public async Task<ActionResult<LoanReadDto>> GetByBook([FromRoute] int bookID) =>
        Ok(await _loanService.GetLoanByBookAsync(bookID));

    [HttpPost]
    public async Task<ActionResult<LoanReadDto>> Post([FromBody] LoanCreateDto dto)
    {
        var result = await _loanService.CreateLoanAsync(dto);
        return CreatedAtAction(nameof(Get), new { id = result.ID }, result);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        await _loanService.DeleteLoanAsync(id);
        return NoContent();
    }
}
