using System.Net;
using System.Net.Http.Json;

using AtlasLMS.Blazor.Features.Locations.Contracts;
using AtlasLMS.Shared.DTOs.Read;
using AtlasLMS.Shared.Responses;

using BlazorBootstrap;

using Microsoft.AspNetCore.Components;

namespace AtlasLMS.Blazor.Features.Locations.Pages;

public partial class LocationsPage
{
    [Inject] public required ILocationService LocationService { get; set; }
    [Inject] public required ToastService ToastService { get; set; }
    [Inject] public required NavigationManager NavigationService { get; set; }

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
            await SwitchExceptionMessage(response);
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

    private async Task SwitchExceptionMessage(HttpResponseMessage response)
    {
        var exceptionResponse = await response.Content.ReadFromJsonAsync<MiddlewareExceptionResponse>();
        if (exceptionResponse is null) return;

        switch (response.StatusCode)
        {
            case HttpStatusCode.NotFound:
                ToastService.Notify(new(ToastType.Danger, "¡Error!", exceptionResponse.Message));
                break;
            case HttpStatusCode.BadRequest:
                ToastService.Notify(new(ToastType.Danger, "¡Error!", exceptionResponse.Message));
                break;
            default:
                ToastService.Notify(new(ToastType.Danger, "¡Error!", exceptionResponse.Message));
                break;
        }
    }
    #endregion
}
