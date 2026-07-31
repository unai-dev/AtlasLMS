using AtlasLMS.Blazor.Features.Users.Contracts;
using AtlasLMS.Shared.DTOs.Create;

using Microsoft.AspNetCore.Components;

namespace AtlasLMS.Blazor.Features.Users.Pages;

public partial class UserMaintenanceCreate
{
    [Inject] public required IUserService UserService { get; set; }
    [Inject] public required NavigationManager NavigationService { get; set; }

    private UserCreateDto user = new();

    #region Actions---------------------------------------------------------------
    private void HandleCancelUser() => NavigationService.NavigateTo("/users");
    private async Task HandleSaveUser(UserCreateDto user) => Console.WriteLine($"Creando: {user.Email}");
    #endregion
}
