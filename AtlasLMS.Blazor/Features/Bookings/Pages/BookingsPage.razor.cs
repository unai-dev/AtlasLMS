using System.Net;
using System.Net.Http.Json;

using AtlasLMS.Blazor.Features.Bookings.Contracts;
using AtlasLMS.Shared.DTOs.Read;
using AtlasLMS.Shared.Responses;

using BlazorBootstrap;

using Microsoft.AspNetCore.Components;

namespace AtlasLMS.Blazor.Features.Bookings.Pages;

public partial class BookingsPage
{
    [Inject] public required IBookingService BookingService { get; set; }
    [Inject] public required ToastService ToastService { get; set; }

    private List<BookingReadDto> bookings = new List<BookingReadDto>();
    private ConfirmDialog? dialog;
    private bool isLoading = false;

    #region OnInitialized----------------------------------------------------------------
    protected override async Task OnInitializedAsync()
    {
        await RefreshBookings();
    }
    #endregion

    #region ButtonActions----------------------------------------------------------------
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

            await SwitchExceptionMessage(response);
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
        ToastService.Notify(new(ToastType.Success, "¡Listo!", "Reservas cargadas correctamente"));
    }

    private async Task SwitchExceptionMessage(HttpResponseMessage response)
    {

        var exceptionResponse = await response.Content.ReadFromJsonAsync<MiddlewareExceptionResponse>();
        if (exceptionResponse is null) return;
        switch (response.StatusCode)
        {
            case HttpStatusCode.NotFound:
            case HttpStatusCode.BadRequest:
            case HttpStatusCode.InternalServerError:
                ToastService.Notify(new(ToastType.Success, "¡Error!", exceptionResponse.Message));
                break;
        }
    }
    #endregion
}
