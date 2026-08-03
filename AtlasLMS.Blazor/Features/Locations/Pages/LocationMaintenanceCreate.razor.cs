using AtlasLMS.Blazor.Features.Locations.Contracts;
using AtlasLMS.Blazor.Security.Contracts;
using AtlasLMS.Shared.DTOs.Create;

using BlazorBootstrap;

using Microsoft.AspNetCore.Components;

namespace AtlasLMS.Blazor.Features.Locations.Pages;

public partial class LocationMaintenanceCreate
{
    [Inject] public required ILocationService LocationService { get; set; }
    [Inject] public required ToastService ToastService { get; set; }
    [Inject] public required NavigationManager NavigationService { get; set; }
    [Inject] public required IAtlasExceptionHandler AtlasExceptionHandler { get; set; }

    private LocationCreateDto location = new();
    private bool currentPost = false;

    #region Methods-----------------------------------------------------------------------------
    private void HandleCancel() => NavigationService.NavigateTo("/locations");
    private async Task HandleAddLocation(LocationCreateDto location)
    {
        currentPost = true;

        var response = await LocationService.CreateLocationAsync(location);
        currentPost = false;

        if (response.IsSuccessStatusCode)
        {
            ToastService.Notify(new(ToastType.Success, "¡Listo!", "Ubicación creada correctamente."));
            NavigationService.NavigateTo("/locations");
            return;
        }
        await AtlasExceptionHandler.SwitchExceptionMessage(response);
    }
    #endregion
}
