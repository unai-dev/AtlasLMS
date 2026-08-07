using AtlasLMS.Blazor.Features.Bookings.Contracts;
using AtlasLMS.Blazor.Security.Contracts;
using AtlasLMS.Shared.DTOs.Read;

using BlazorBootstrap;

using Microsoft.AspNetCore.Components;

namespace AtlasLMS.Blazor.Features.Bookings.Pages;

public partial class BookingsPage
{
    [Inject] public required IBookingService BookingService { get; set; }
    [Inject] public required ToastService ToastService { get; set; }
    [Inject] public required NavigationManager NavigationService { get; set; }
    [Inject] public required IAtlasExceptionHandler AtlasExceptionHandler { get; set; }

    private List<BookingReadDto> bookings = new List<BookingReadDto>();
    private ConfirmDialog dialog = default!;
    private bool isLoading = false;

    #region OnInitialized----------------------------------------------------------------
    protected override async Task OnInitializedAsync()
    {
        await RefreshBookings();
    }
    #endregion

    #region ButtonActions----------------------------------------------------------------
    private void HandleAddBooking() => NavigationService.NavigateTo("/bookings/create");
    private void HandleViewBooking(int ID) => NavigationService.NavigateTo($"/bookings/{ID}");
    private async Task HandleDeleteBooking(int ID)
    {
        var confirm = await dialog.ShowAsync($"¿Esta seguro que desea eliminar este elemento?", "Esta acción no se puede deshacer.");
        if (confirm)
        {
            var response = await BookingService.DeleteBookingAsync(ID);
            if (response.IsSuccessStatusCode)
            {
                ToastService.Notify(new(ToastType.Success, "¡Listo!", "Reserva eliminada con exito"));
                await RefreshBookings();
                return;
            }

            await AtlasExceptionHandler.SwitchExceptionMessage(response);
        }
        return;
    }
    #endregion

    #region Methods----------------------------------------------------------------------
    private async Task RefreshBookings()
    {
        isLoading = true;
        bookings = (await BookingService.GetBookingsAsync()).ToList();
        isLoading = false;
        if (bookings.Count == 0)
        {
            ToastService.Notify(new(ToastType.Info, "¡Info!", "No hay reservas disponibles"));
            return;
        }
    }
    #endregion
}
