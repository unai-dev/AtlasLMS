using AtlasLMS.Application.Contracts;
using AtlasLMS.Domain.Entities;
using AtlasLMS.Shared.DTOs.Create;
using AtlasLMS.Shared.DTOs.Detail;
using AtlasLMS.Shared.DTOs.Read;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AtlasLMS.API.Controllers;

[ApiController]
[Route("api/bookings")]
[Authorize]
public class BookingController : ControllerBase
{
    private readonly IBookingService _bookingService;

    public BookingController(IBookingService bookingService)
    {
        _bookingService = bookingService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BookingReadDto>>> GetAll([FromQuery] EBookingStatus? status)
    {
        if (status is not null)
            return Ok(await _bookingService.GetBookingsByStatusAsync(status));

        return Ok(await _bookingService.GetBookingsAsync());
    }

    [HttpGet("user/{userID}")]
    public async Task<ActionResult<IEnumerable<BookingReadDto>>> GetByUser(string userID) =>
        Ok(await _bookingService.GetBookingsByUserAsync(userID));

    [HttpGet("{id:int}")]
    public async Task<ActionResult<BookingReadDto>> Get(int id) =>
        Ok(await _bookingService.GetBookingAsync(id));

    [HttpGet("book/{bookID:int}")]
    public async Task<ActionResult<IEnumerable<BookingReadDto>>> GetByBook(int bookID) =>
        Ok(await _bookingService.GetBookingByBookAsync(bookID));

    [HttpGet("detail/{ID:int}")]
    public async Task<ActionResult<BookingDetailDto>> GetDetail(int ID) =>
        Ok(await _bookingService.GetBookingDetailAsync(ID));

    [HttpPost]
    public async Task<ActionResult<BookingReadDto>> Create([FromBody] BookingCreateDto dto)
    {
        var booking = await _bookingService.CreateBookingAsync(dto);
        return CreatedAtAction(nameof(Get), new { id = booking.ID }, booking);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _bookingService.DeleteBookingAsync(id);
        return NoContent();
    }
}
