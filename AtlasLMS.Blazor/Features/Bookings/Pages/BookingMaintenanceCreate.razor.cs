using AtlasLMS.Blazor.Features.Bookings.Contracts;
using AtlasLMS.Blazor.Features.Books.Contracts;
using AtlasLMS.Blazor.Features.Users.Contracts;
using AtlasLMS.Blazor.Security.Contracts;
using AtlasLMS.Shared.DTOs.Create;
using AtlasLMS.Shared.DTOs.Read;

using BlazorBootstrap;

using Microsoft.AspNetCore.Components;

namespace AtlasLMS.Blazor.Features.Bookings.Pages;

public partial class BookingMaintenanceCreate
{
    [Inject] public required IBookingService bookingService { get; set; }
    [Inject] public required IBookService BookService { get; set; }
    [Inject] public required IUserService UserService { get; set; }
    [Inject] public required IAtlasExceptionHandler AtlasExceptionHandler { get; set; }
    [Inject] public required ToastService ToastService { get; set; }
    [Inject] public required NavigationManager NavigationService { get; set; }

    private List<BookReadDto> books = new();
    private List<UserReadDto> users = new();
    private BookingCreateDto booking = new();
    private bool currentPost = false;

    #region OnInitialized---------------------------------------------------------------------
    protected override async Task OnInitializedAsync()
    {
        books = (await BookService.GetBooksAsync()).ToList();
        users = (await UserService.GetUsersAsync()).ToList();
    }
    #endregion

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
