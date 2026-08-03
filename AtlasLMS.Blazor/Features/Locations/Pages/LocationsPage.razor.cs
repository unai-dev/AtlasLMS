using AtlasLMS.Blazor.Features.Locations.Contracts;
using AtlasLMS.Blazor.Security.Contracts;
using AtlasLMS.Shared.DTOs.Read;

using BlazorBootstrap;

using Microsoft.AspNetCore.Components;

namespace AtlasLMS.Blazor.Features.Locations.Pages;

public partial class LocationsPage
{
    [Inject] public required ILocationService LocationService { get; set; }
    [Inject] public required ToastService ToastService { get; set; }
    [Inject] public required NavigationManager NavigationService { get; set; }
    [Inject] public required IAtlasExceptionHandler AtlasExceptionHandler { get; set; }

    private List<LocationReadDto>? locations;
    private ConfirmDialog dialog = default!;
    private bool isLoading = false;

    #region OnInitialized----------------------------------------------------------------
    protected override async Task OnInitializedAsync()
    {
        await RefreshLocations();
    }
    #endregion

    #region ButtonActions----------------------------------------------------------------
    private async Task HandleAddLocation() => NavigationService.NavigateTo($"/locations/create");
    private async Task HandleDeleteLocation(int ID)
    {
        var confirm = await dialog.ShowAsync($"¿Esta seguro que desea eliminar este elemento?", "Esta acción no se puede deshacer.");
        if (confirm)
        {
            var response = await LocationService.DeleteLocationAsync(ID);
            if (response.IsSuccessStatusCode)
            {
                ToastService.Notify(new(ToastType.Success, "¡Listo!", "Ubicación eliminada con exito"));
                await RefreshLocations();
                return;
            }
            await AtlasExceptionHandler.SwitchExceptionMessage(response);
        }
        return;
    }
    #endregion

    #region Methods----------------------------------------------------------------------
    private async Task RefreshLocations()
    {
        isLoading = true;
        locations = (await LocationService.GetLocationsAsync()).ToList();
        isLoading = false;

        if (locations.Count == 0)
        {
            ToastService.Notify(new(ToastType.Info, "¡Info!", "No hay ubicaciones disponibles"));
            return;
        }
    }
    #endregion
}
