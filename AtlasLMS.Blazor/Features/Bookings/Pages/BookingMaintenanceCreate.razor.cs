using AtlasLMS.Blazor.Features.Bookings.Contracts;
using AtlasLMS.Blazor.Security.Contracts;
using AtlasLMS.Shared.DTOs.Create;

using BlazorBootstrap;

using Microsoft.AspNetCore.Components;

namespace AtlasLMS.Blazor.Features.Bookings.Pages;

public partial class BookingMaintenanceCreate
{
    [Inject] public required IBookingService bookingService { get; set; }
    [Inject] public required ToastService ToastService { get; set; }
    [Inject] public required NavigationManager NavigationService { get; set; }
    [Inject] public required IAtlasExceptionHandler AtlasExceptionHandler { get; set; }

    private BookingCreateDto booking = new();
    private bool currentPost = false;

    #region Actions-----------------------------------------------------------------------
    private void HandleCancel() => NavigationService.NavigateTo("/bookings");
    private async Task HandleSaveBooking(BookingCreateDto booking)
    {
        currentPost = true;
        var response = await bookingService.CreateBookingAsync(booking);

        if (response.IsSuccessStatusCode)
        {
            ToastService.Notify(new(ToastType.Success, "¡Listo!", "Reserva creada correctamente."));
            NavigationService.NavigateTo("/bookings");
            return;
        }
        await AtlasExceptionHandler.SwitchExceptionMessage(response);
        currentPost = false;
    }
    #endregion
}
