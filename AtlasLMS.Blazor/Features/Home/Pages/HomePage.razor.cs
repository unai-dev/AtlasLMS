using AtlasLMS.Shared.DTOs.Read;

namespace AtlasLMS.Blazor.Features.Home.Pages;

public partial class HomePage
{
    private UserReadDto? user;
    private bool isLoading = false;

    #region OnInitialized-----------------------------------------------------------------
    protected override async Task OnInitializedAsync()
    {
        isLoading = true;

        user = await UserService.GetMe();
        if (user is null) return;

        isLoading = false;
    }
    #endregion
}
