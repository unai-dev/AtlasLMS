using AtlasLMS.Blazor.Features.Locations.Contracts;
using AtlasLMS.Shared.DTOs.Create;

using BlazorBootstrap;

using Microsoft.AspNetCore.Components;

namespace AtlasLMS.Blazor.Features.Locations.Pages;

public partial class LocationMaintenanceCreate
{
    [Inject] public required ILocationService LocationService { get; set; }
    [Inject] public required ToastService ToastService { get; set; }
    [Inject] public required NavigationManager NavigationService { get; set; }

    private LocationCreateDto location = new();
    private bool currentPost = false;

    #region Methods-----------------------------------------------------------------------------
    private void HandleCancel() => NavigationService.NavigateTo("/locations");
    private async Task HandleAddLocation(LocationCreateDto location)
    {
        currentPost = true;

        await LocationService.CreateLocationAsync(location);
        ToastService.Notify(new(ToastType.Success, "¡Listo!", "Ubicación creada correctamente."));
        NavigationService.NavigateTo("/locations");

        currentPost = false;
    }
    #endregion
}
