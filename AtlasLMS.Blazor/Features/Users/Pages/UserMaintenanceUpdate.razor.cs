using AtlasLMS.Blazor.Features.Users.Contracts;
using AtlasLMS.Blazor.Security.Contracts;
using AtlasLMS.Shared.DTOs.Read;
using AtlasLMS.Shared.DTOs.Update;

using BlazorBootstrap;

using Microsoft.AspNetCore.Components;

namespace AtlasLMS.Blazor.Features.Users.Pages;

public partial class UserMaintenanceUpdate
{
    #region Parameters-----------------------------------------------------------
    [Parameter] public required string ID { get; set; }
    #endregion

    [Inject] public required IUserService UserService { get; set; }
    [Inject] public required NavigationManager NavigationService { get; set; }
    [Inject] public required IAtlasExceptionHandler AtlasExceptionHandler { get; set; }
    [Inject] public required ToastService ToastService { get; set; }

    private UserReadDto? userReadOnly;
    private UserUpdateDto user = new();
    private bool currentPost = false;

    #region OnParametersSet---------------------------------------------------------
    protected override async Task OnParametersSetAsync()
    {
        userReadOnly = await UserService.GetUserAsync(ID);
        if (userReadOnly is null) return;

        user.Email = userReadOnly.Email;
        user.CIF = userReadOnly.CIF;
        user.UserName = userReadOnly.UserName;
    }
    #endregion

    #region Actions---------------------------------------------------------------
    private void HandleCancelUser() => NavigationService.NavigateTo("/users");
    private async Task HandleSaveUser(UserUpdateDto user)
    {
        currentPost = true;
        var response = await UserService.UpdateUserAsync(ID, user);
        currentPost = false;

        if (response.IsSuccessStatusCode)
        {
            NavigationService.NavigateTo("/users");
            ToastService.Notify(new(ToastType.Success, "¡Listo!", "Usuario actualizado con exito"));
            return;
        }

        await AtlasExceptionHandler.SwitchExceptionMessage(response);
    }
    #endregion
}
