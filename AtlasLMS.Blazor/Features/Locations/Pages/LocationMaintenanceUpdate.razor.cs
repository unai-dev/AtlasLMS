using AtlasLMS.Blazor.Features.Locations.Contracts;
using AtlasLMS.Blazor.Security.Contracts;
using AtlasLMS.Shared.DTOs.Read;
using AtlasLMS.Shared.DTOs.Update;

using BlazorBootstrap;

using Microsoft.AspNetCore.Components;

namespace AtlasLMS.Blazor.Features.Locations.Pages;

public partial class LocationMaintenanceUpdate
{
    #region Parameters-----------------------------------------------------------------------
    [Parameter] public int ID { get; set; }
    #endregion

    [Inject] public required ILocationService LocationService { get; set; }
    [Inject] public required NavigationManager NavigationService { get; set; }
    [Inject] public required IAtlasExceptionHandler AtlasExceptionHandler { get; set; }
    [Inject] public required ToastService ToastService { get; set; }

    private LocationReadDto? locationReadOnly;
    private LocationUpdateDto location = new();
    private bool currentPost;

    #region OnParametersSet------------------------------------------------------------------
    protected override async Task OnParametersSetAsync()
    {
        locationReadOnly = await LocationService.GetLocationAsync(ID);
        if (locationReadOnly is null) return;

        location = new LocationUpdateDto
        {
            Aisle = locationReadOnly.Aisle,
            Column = locationReadOnly.Column,
            Shelf = locationReadOnly.Shelf,
            LimitOfBooks = locationReadOnly.LimitOfBooks,
        };
    }
    #endregion

    #region Actions--------------------------------------------------------------------------
    private void HandleCancel() => NavigationService.NavigateTo("/locations");
    private async Task HandleSaveLocation(LocationUpdateDto dto)
    {
        currentPost = true;

        var response = await LocationService.UpdateLocationAsync(ID, dto);
        if (response.IsSuccessStatusCode)
        {
            ToastService.Notify(new(ToastType.Success, "¡Listo!", "Ubicación actualizada con exito"));
            NavigationService.NavigateTo("/locations");
            return;
        }
        await AtlasExceptionHandler.SwitchExceptionMessage(response);
        currentPost = false;
    }
    #endregion
}
