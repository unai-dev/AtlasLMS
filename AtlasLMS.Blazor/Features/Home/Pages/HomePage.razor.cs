using AtlasLMS.Blazor.Security.Contracts;
using AtlasLMS.Shared.DTOs.Read;

using Microsoft.AspNetCore.Components;

namespace AtlasLMS.Blazor.Features.Home.Pages;

public partial class HomePage
{
    [Inject] public required ILocalStorageService LocalStorageService { get; set; }
    [Inject] public required NavigationManager NavigationService { get; set; }

    private UserReadDto? user;
    private bool isLoading = false;

    #region OnInitialized-----------------------------------------------------------------
    protected override async Task OnInitializedAsync()
    {
        isLoading = true;
        user = await UserService.GetMe();
        isLoading = false;
    }
    #endregion

    #region Actions----------------------------------------------------------------------
    private async Task HandleLogout()
    {
        await LocalStorageService.RemoveItemAsync("token");
        NavigationService.NavigateTo("/login");
    }
    #endregion
}
