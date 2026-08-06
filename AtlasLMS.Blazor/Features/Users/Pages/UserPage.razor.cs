using AtlasLMS.Blazor.Features.Users.Contracts;
using AtlasLMS.Shared.DTOs.Detail;

using Microsoft.AspNetCore.Components;

namespace AtlasLMS.Blazor.Features.Users.Pages;

public partial class UserPage
{
    #region Parameters------------------------------------------------------
    [Parameter] public required string ID { get; set; }
    #endregion

    [Inject] public required IUserService UserService { get; set; }
    [Inject] public required NavigationManager NavigationService { get; set; }

    private UserDetailDto? user;
    private bool isLoading = false;

    #region OnParametersSet------------------------------------------------
    protected override async Task OnParametersSetAsync()
    {
        isLoading = true;

        user = await UserService.GetUserAsync(ID);
        if (user is null) return;

        isLoading = false;
    }
    #endregion

    #region Actions--------------------------------------------------------
    private void HandleReturn() => NavigationService.NavigateTo("/users");
    #endregion
}
