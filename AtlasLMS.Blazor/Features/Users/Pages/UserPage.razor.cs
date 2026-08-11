using AtlasLMS.Blazor.Features.Auth.Contracts;
using AtlasLMS.Blazor.Features.Users.Contracts;
using AtlasLMS.Blazor.Security.Contracts;
using AtlasLMS.Shared.DTOs.Auth;
using AtlasLMS.Shared.DTOs.Detail;

using BlazorBootstrap;

using Microsoft.AspNetCore.Components;

namespace AtlasLMS.Blazor.Features.Users.Pages;

public partial class UserPage
{
    #region Parameters------------------------------------------------------
    [Parameter] public required string ID { get; set; }
    #endregion

    [Inject] public required IUserService UserService { get; set; }
    [Inject] public required IAuthService AuthService { get; set; }
    [Inject] public required IAtlasExceptionHandler AtlasExceptionHandler { get; set; }
    [Inject] public required NavigationManager NavigationService { get; set; }
    [Inject] public required ToastService ToastService { get; set; }

    private UserDetailDto? user;
    private ClaimDto? claim;
    private bool isLoading = false;
    private bool currentPost = false;

    #region OnParametersSet------------------------------------------------
    protected override async Task OnParametersSetAsync()
    {
        isLoading = true;

        user = await UserService.GetUserDetailAsync(ID);
        if (user is null) return;

        claim = new ClaimDto { Email = user.Email };

        isLoading = false;
    }
    #endregion

    #region Actions--------------------------------------------------------
    private void HandleReturn() => NavigationService.NavigateTo("/users");
    //Bookings y Loans, son paginas provisionales
    //El usuario cuando haga click para ver reservas
    //o prestamos, se redirecionara a una pagina especial que unicamente mostrara sus prestamos/reservas
    private void HandleBookings() => NavigationService.NavigateTo("/bookings");
    private void HandleLoans() => NavigationService.NavigateTo("/loans");
    private async Task HandleAddAdmin()
    {
        currentPost = true;

        if (claim is null) return;

        var response = await AuthService.MakeAdmin(claim);
        if (response.IsSuccessStatusCode)
        {
            ToastService.Notify(new(ToastType.Success, "¡Listo!", "Se agrego como administrador de Atlas el usuario correctamente."));
            currentPost = false;
            return;
        }
        await AtlasExceptionHandler.SwitchExceptionMessage(response);
        currentPost = false;
    }

    private async Task HandleRemoveAdmin()
    {
        currentPost = true;
        if (claim is null) return;

        var response = await AuthService.RemoveAdmin(claim);
        if (response.IsSuccessStatusCode)
        {
            ToastService.Notify(new(ToastType.Success, "¡Listo!", "Se elimino como administrador de Atlas el usuario correctamente."));
            currentPost = false;
            return;
        }

        await AtlasExceptionHandler.SwitchExceptionMessage(response);
        currentPost = false;
    }
    #endregion
}
