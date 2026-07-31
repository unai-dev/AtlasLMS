using AtlasLMS.Blazor.Features.Users.Contracts;
using AtlasLMS.Shared.DTOs.Create;

using BlazorBootstrap;

using Microsoft.AspNetCore.Components;

namespace AtlasLMS.Blazor.Features.Users.Pages;

public partial class UserMaintenanceCreate
{
    [Inject] public required IUserService UserService { get; set; }
    [Inject] public required NavigationManager NavigationService { get; set; }
    [Inject] public required ToastService ToastService { get; set; }

    private UserCreateDto user = new();
    private bool currentPost = false;

    #region Actions---------------------------------------------------------------
    private void HandleCancelUser() => NavigationService.NavigateTo("/users");
    private async Task HandleSaveUser(UserCreateDto user)
    {
        if (user == null) return;

        currentPost = true;
        await UserService.CreateUserAsync(user);

        NavigationService.NavigateTo("/users");
        ToastService.Notify(new(ToastType.Success, "¡Listo!", "Usuario creado con exito"));

        currentPost = false;
    }
    #endregion
}
