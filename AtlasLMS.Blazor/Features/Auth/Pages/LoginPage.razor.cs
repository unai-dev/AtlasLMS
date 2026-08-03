using AtlasLMS.Shared.DTOs.Auth;

namespace AtlasLMS.Blazor.Features.Auth.Pages;

public partial class LoginPage
{
    private LoginDto loginUser = new LoginDto();
    private bool currentPost = false;

    #region Actions---------------------------------------------------------------------------
    private async Task HandleLogin()
    {
        currentPost = true;
        var result = await AuthService.LoginAsync(loginUser);

        if (string.IsNullOrWhiteSpace(result!.Token)) return;

        await LocalStorage.SetItemAsync("token", result.Token);
        Navigation.NavigateTo("/");

        currentPost = false;
    }
    #endregion
}
