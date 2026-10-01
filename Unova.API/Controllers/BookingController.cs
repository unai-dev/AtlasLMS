using Microsoft.AspNetCore.Mvc;
using Unova.API.Controllers.Common;
using Unova.App.Contracts;
using Unova.Shared.DTOs.Create;
using Unova.Shared.DTOs.Detail;
using Unova.Shared.DTOs.Read;

namespace Unova.API.Controllers;

[Route("api/bookings")]
public class BookingController : UnovaController
{
    private readonly IBookingService _bookingService;

    public BookingController(IBookingService bookingService)
    {
        _bookingService = bookingService;
    }

    [HttpGet("user/{userID}")]
    public async Task<ActionResult<IEnumerable<BookingReadDto>>> GetByUser(int userID) =>
        Ok(await _bookingService.GetBookingsByUserAsync(userID));

    [HttpGet("{id:int}")]
    public async Task<ActionResult<BookingReadDto>> Get(int id) =>
        Ok(await _bookingService.GetByID(id));

    [HttpGet("detail/{ID:int}")]
    public async Task<ActionResult<BookingDetailDto>> GetDetail(int ID) =>
        Ok(await _bookingService.GetDetail(ID));

    [HttpPost]
    public async Task<ActionResult<BookingReadDto>> Create([FromBody] BookingCreateDto dto)
    {
        var booking = await _bookingService.Create(dto);
        return CreatedAtAction(nameof(Get), new { id = booking.ID }, booking);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _bookingService.Delete(id);
        return NoContent();
    }
}
