using System.Net.Http.Json;

using AtlasLMS.Blazor.Features.Bookings.Contracts;
using AtlasLMS.Shared.DTOs.Create;
using AtlasLMS.Shared.DTOs.Detail;
using AtlasLMS.Shared.DTOs.Read;

namespace AtlasLMS.Blazor.Features.Bookings.Services;

public class BookingService : IBookingService
{
    private readonly HttpClient _http;

    public BookingService(HttpClient http)
    {
        _http = http;
    }

    public async Task<IEnumerable<BookingReadDto>> GetBookingsAsync() =>
        await _http.GetFromJsonAsync<IEnumerable<BookingReadDto>>("bookings") ?? [];

    public async Task<BookingDetailDto?> GetBookingDetailAsync(int ID) =>
        await _http.GetFromJsonAsync<BookingDetailDto>($"bookings/detail/{ID}");

    public async Task<HttpResponseMessage> CreateBookingAsync(BookingCreateDto dto) =>
        await _http.PostAsJsonAsync("bookings", dto);

    public async Task<HttpResponseMessage> DeleteBookingAsync(int ID) =>
        await _http.DeleteAsync($"bookings/{ID}");
}
