using AtlasLMS.Blazor.Features.Users.Contracts;
using AtlasLMS.Blazor.Security.Contracts;
using AtlasLMS.Shared.DTOs.Read;

using BlazorBootstrap;

using Microsoft.AspNetCore.Components;

namespace AtlasLMS.Blazor.Features.Users.Pages;

public partial class UsersPage
{
    [Inject] public required IUserService UserService { get; set; }
    [Inject] public required ToastService ToastService { get; set; }
    [Inject] public required NavigationManager NavigationService { get; set; }
    [Inject] public required IAtlasExceptionHandler AtlasExceptionHandler { get; set; }

    private List<UserReadDto> users = new List<UserReadDto>();
    private ConfirmDialog dialog = default!;
    private bool isLoading = false;

    #region OnInitialized----------------------------------------------------------
    protected override async Task OnInitializedAsync()
    {

        await RefreshUsers();
    }
    #endregion

    #region ButtonActions----------------------------------------------------------
    private void HandleNewUser() => NavigationService.NavigateTo("/users/create");
    private void HandleViewUser(string ID) => NavigationService.NavigateTo($"users/{ID}");
    private async Task HandleDeleteUser(string ID)
    {
        var confirm = await dialog.ShowAsync($"¿Esta seguro que desea eliminar este elemento?", "Esta acción no se puede deshacer.");
        if (confirm)
        {
            var response = await UserService.DeleteUserAsync(ID);
            if (response.IsSuccessStatusCode)
            {
                ToastService.Notify(new(ToastType.Success, "¡Listo!", "Usuario eliminado correctamente"));
                await RefreshUsers();
                return;
            }
            await AtlasExceptionHandler.SwitchExceptionMessage(response);
        }
        return;
    }
    #endregion

    #region Methods----------------------------------------------------------------------
    private async Task RefreshUsers()
    {
        isLoading = true;
        users = (await UserService.GetUsersAsync()).ToList();
        isLoading = false;
    }
    #endregion
}
