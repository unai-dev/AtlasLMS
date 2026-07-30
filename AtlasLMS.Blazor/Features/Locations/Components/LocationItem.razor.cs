using AtlasLMS.Shared.DTOs.Read;

using Microsoft.AspNetCore.Components;

namespace AtlasLMS.Blazor.Features.Locations.Components;

public partial class LocationItem
{
    #region Parameters-----------------------------------------------------------
    [Parameter, EditorRequired] public LocationReadDto Location { get; set; }
    [Parameter] public EventCallback<int> OnView { get; set; }
    [Parameter] public EventCallback<int> OnEdit { get; set; }
    [Parameter] public EventCallback<int> OnDelete { get; set; }
    #endregion
}
