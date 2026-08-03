using AtlasLMS.Blazor.Features.Users.Contracts;
using AtlasLMS.Blazor.Security.Contracts;
using AtlasLMS.Shared.DTOs.Create;

using BlazorBootstrap;

using Microsoft.AspNetCore.Components;

namespace AtlasLMS.Blazor.Features.Users.Pages;

public partial class UserMaintenanceCreate
{
    [Inject] public required IUserService UserService { get; set; }
    [Inject] public required NavigationManager NavigationService { get; set; }
    [Inject] public required IAtlasExceptionHandler AtlasExceptionHandler { get; set; }
    [Inject] public required ToastService ToastService { get; set; }

    private UserCreateDto user = new();
    private bool currentPost = false;

    #region Actions---------------------------------------------------------------
    private void HandleCancelUser() => NavigationService.NavigateTo("/users");
    private async Task HandleSaveUser(UserCreateDto user)
    {
        currentPost = true;
        var response = await UserService.CreateUserAsync(user);
        currentPost = false;

        if (response.IsSuccessStatusCode)
        {
            NavigationService.NavigateTo("/users");
            ToastService.Notify(new(ToastType.Success, "¡Listo!", "Usuario creado con exito"));
            return;
        }

        await AtlasExceptionHandler.SwitchExceptionMessage(response);
    }
    #endregion
}
