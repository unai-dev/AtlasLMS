using AtlasLMS.Application.Services;
using AtlasLMS.Shared.DTOs.Create;
using AtlasLMS.Shared.Enums;

using Microsoft.AspNetCore.Mvc;

namespace AtlasLMS.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookingController : ControllerBase
{
    private readonly BookingService _bookingService;

    public BookingController(BookingService bookingService)
    {
        _bookingService = bookingService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() =>
        Ok(await _bookingService.GetBookingsAsync());

    [HttpGet("user/{userID}")]
    public async Task<IActionResult> GetByUser(string userID) =>
        Ok(await _bookingService.GetBookingsByUserAsync(userID));


    [HttpGet("status/{status}")]
    public async Task<IActionResult> GetByStatus(EBookingStatus status) =>
        Ok(await _bookingService.GetBookingsByStatusAsync(status));

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id) =>
        Ok(await _bookingService.GetBookingAsync(id));

    [HttpGet("book/{bookID:int}")]
    public async Task<IActionResult> GetByBook(int bookID) =>
        Ok(await _bookingService.GetBookingByBookAsync(bookID));

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] BookingCreateDto dto)
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
