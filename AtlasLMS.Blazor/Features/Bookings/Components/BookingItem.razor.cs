using AtlasLMS.Shared.DTOs.Read;

using Microsoft.AspNetCore.Components;

namespace AtlasLMS.Blazor.Features.Bookings.Components;

public partial class BookingItem
{
    #region Parameters------------------------------------------------------------------
    [Parameter, EditorRequired] public BookingReadDto Booking { get; set; }
    [Parameter] public EventCallback<int> OnView { get; set; }
    [Parameter] public EventCallback<int> OnDelete { get; set; }
    [Parameter] public EventCallback<int> OnEdit { get; set; }
    #endregion
}
