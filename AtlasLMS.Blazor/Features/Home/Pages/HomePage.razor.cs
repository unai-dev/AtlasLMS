using AtlasLMS.Shared.DTOs.Read;

using BlazorBootstrap;

namespace AtlasLMS.Blazor.Features.Home.Pages;

public partial class HomePage
{
    private UserReadDto? user;
    private bool isLoading = false;

    #region OnInitialized-----------------------------------------------------------------
    protected override async Task OnInitializedAsync()
    {
        try
        {
            isLoading = true;
            var result = await LocalStorage.GetItemAsync("token");

            if (string.IsNullOrEmpty(result))
            {
                Navigation.NavigateTo("/login");
                return;
            }
            user = await UserService.GetMe();

            if (user is null)
                return;
        }
        catch (Exception ex)
        {
            ToastService.Notify(new(ToastType.Danger, "¡Error!", "Verificando autenticacion"));
            Console.WriteLine("Error verificando autenticacion");
            Console.WriteLine(ex);
        }
        finally
        {
            isLoading = false;
        }
    }
    #endregion
}
