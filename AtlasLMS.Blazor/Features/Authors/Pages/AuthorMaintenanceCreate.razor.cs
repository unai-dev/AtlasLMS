using AtlasLMS.Blazor.Features.Authors.Contracts;
using AtlasLMS.Blazor.Security.Contracts;
using AtlasLMS.Shared.DTOs.Create;

using BlazorBootstrap;

using Microsoft.AspNetCore.Components;

namespace AtlasLMS.Blazor.Features.Authors.Pages;

public partial class AuthorMaintenanceCreate
{
    [Inject] public required IAuthorService AuthorService { get; set; }
    [Inject] public required ToastService ToastService { get; set; }
    [Inject] public required NavigationManager NavigationService { get; set; }
    [Inject] public required IAtlasExceptionHandler AtlasExceptionHandler { get; set; }

    private AuthorCreateDto author = new();
    private bool currentPost = false;

    #region Actions-------------------------------------------------------------------------------
    private void HandleCancel() => NavigationService.NavigateTo("/authors");
    private async Task HandleSaveAuthor(AuthorCreateDto author)
    {
        currentPost = true;
        var response = await AuthorService.CreateAuthorAsync(author);

        if (response.IsSuccessStatusCode)
        {
            ToastService.Notify(new(ToastType.Success, "¡Listo!", "Autor creado correctamente."));
            NavigationService.NavigateTo("/authors");
            return;
        }
        await AtlasExceptionHandler.SwitchExceptionMessage(response);
        currentPost = false;
    }
    #endregion
}
