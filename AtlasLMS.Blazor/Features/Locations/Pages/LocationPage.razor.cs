using AtlasLMS.Blazor.Features.Locations.Contracts;
using AtlasLMS.Shared.DTOs.Detail;

using Microsoft.AspNetCore.Components;

namespace AtlasLMS.Blazor.Features.Locations.Pages;

public partial class LocationPage
{
    #region Parameters------------------------------------------------------------------
    [Parameter] public int ID { get; set; }
    #endregion

    [Inject] public required ILocationService LocationService { get; set; }
    [Inject] public required NavigationManager NavigationService { get; set; }

    private LocationDetailDto? location;
    private bool isLoading = false;

    #region OnParametersSet--------------------------------------------------------------
    protected override async Task OnParametersSetAsync()
    {
        isLoading = true;

        location = await LocationService.GetLocationDetailAsync(ID);
        if (location is null) return;

        isLoading = false;
    }
    #endregion

    #region Actions----------------------------------------------------------------------
    private void HandleReturn() => NavigationService.NavigateTo("/locations");
    //Provisional
    private void HandleBooks() => NavigationService.NavigateTo("/books");
    #endregion
}
