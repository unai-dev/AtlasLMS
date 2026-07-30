using System.Net;
using System.Net.Http.Json;

using AtlasLMS.Shared.DTOs.Read;
using AtlasLMS.Shared.Responses;

using BlazorBootstrap;

namespace AtlasLMS.Blazor.Features.Users.Pages;

public partial class UsersPage
{
    private List<UserReadDto>? users;
    private bool isLoading = false;

    #region OnInitialized----------------------------------------------------------
    protected override async Task OnInitializedAsync()
    {
        await RefreshUsers();
    }
    #endregion

    #region ButtonActions----------------------------------------------------------
    private async Task HandleDeleteUser(string ID)
    {
        var response = await UserService.DeleteUserAsync(ID);
        if (response.IsSuccessStatusCode)
        {
            ToastService.Notify(new(ToastType.Success, "¡Listo!", "Usuario eliminado correctamente"));
            await RefreshUsers();
            return;
        }
        await SwitchExceptionMessage(response);
    }
    #endregion

    #region Methods----------------------------------------------------------------------
    private async Task RefreshUsers()
    {
        isLoading = true;
        users = (await UserService.GetUsersAsync()).ToList();
        isLoading = false;

        //Validacion inecesaria
        //No tiene sentido valorar si es que hay usuarios en el sistema o no
        //Minimo siempre hay un usuario
        //La mantenemos por control temporal
        if (users.Count == 0)
        {
            ToastService.Notify(new(ToastType.Info, "¡Info!", "No hay usuarios disponibles en el sistema"));

            return;
        }
        ToastService.Notify(new(ToastType.Success, "¡Listo!", "Usuarios cargados correctamente"));
    }

    private async Task SwitchExceptionMessage(HttpResponseMessage response)
    {
        var exceptionResponse = await response.Content.ReadFromJsonAsync<MiddlewareExceptionResponse>();
        if (exceptionResponse is null) return;
        switch (response.StatusCode)
        {
            case HttpStatusCode.NotFound:
                ToastService.Notify(new(ToastType.Danger, "¡Error!", exceptionResponse.Message));
                break;
            case HttpStatusCode.BadRequest:
                ToastService.Notify(new(ToastType.Danger, "¡Error!", exceptionResponse.Message));
                break;
            default:
                ToastService.Notify(new(ToastType.Danger, "¡Error!", exceptionResponse.Message));
                break;
        }
    }
    #endregion
}
