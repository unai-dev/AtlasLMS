using AtlasLMS.Shared.DTOs.Auth;
using AtlasLMS.Tools;

using BlazorBootstrap;

namespace AtlasLMS.Blazor.Features.Auth.Pages;

public partial class LoginPage
{
    private LoginDto? loginUser = new LoginDto();
    private bool currentPost;

    #region Methods---------------------------------------------------------------------------
    private async Task HandleLogin()
    {
        try
        {
            if (loginUser is null)
                return;
            currentPost = true;
            var result = await AuthService.LoginAsync(loginUser);

            if (AtlasHelper.IsStringEmpty(result!.Token))
                return;

            await LocalStorage.SetItemAsync("token", result.Token);
            Navigation.NavigateTo("/");

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            ToastService.Notify(new(ToastType.Danger, "¡Error!", "Error al iniciar sesión"));
        }
        finally
        {
            currentPost = false;
        }
    }
    #endregion
}
