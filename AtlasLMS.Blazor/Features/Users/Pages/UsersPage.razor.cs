using System.Net;
using System.Net.Http.Json;

using AtlasLMS.Blazor.Features.Users.Contracts;
using AtlasLMS.Shared.DTOs.Read;
using AtlasLMS.Shared.Responses;

using BlazorBootstrap;

using Microsoft.AspNetCore.Components;

namespace AtlasLMS.Blazor.Features.Users.Pages;

public partial class UsersPage
{
    [Inject] public required IUserService UserService { get; set; }
    [Inject] public required ToastService ToastService { get; set; }
    [Inject] public required NavigationManager NavigationService { get; set; }

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
            await SwitchExceptionMessage(response);
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
            case HttpStatusCode.BadRequest:
            case HttpStatusCode.InternalServerError:
                ToastService.Notify(new(ToastType.Danger, "¡Error!", exceptionResponse.Message));
                break;
        }
    }
    #endregion
}
