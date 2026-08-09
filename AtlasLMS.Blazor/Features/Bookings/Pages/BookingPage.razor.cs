using AtlasLMS.Blazor.Features.Bookings.Contracts;
using AtlasLMS.Shared.DTOs.Detail;

using Microsoft.AspNetCore.Components;

namespace AtlasLMS.Blazor.Features.Bookings.Pages;

public partial class BookingPage
{
    #region Paramaters-----------------------------------------------------------------
    [Parameter] public int ID { get; set; }
    #endregion

    [Inject] public required IBookingService BookingService { get; set; }
    [Inject] public required NavigationManager NavigationService { get; set; }

    private BookingDetailDto? booking;
    private bool isLoading = false;

    #region OnParametersSet------------------------------------------------------------
    protected override async Task OnParametersSetAsync()
    {
        isLoading = true;

        booking = await BookingService.GetBookingDetailAsync(ID);
        if (booking is null) return;

        isLoading = false;
    }
    #endregion

    #region Actions---------------------------------------------------------------------
    private void HandleReturn() => NavigationService.NavigateTo("/bookings");
    private void HandleViewUser(string userID) => NavigationService.NavigateTo($"/users/{userID}");
    private void HandleViewBook(int bookID) => NavigationService.NavigateTo($"/books/{bookID}");
    #endregion
}
