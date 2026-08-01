using AtlasLMS.Blazor.Features.Authors.Contracts;
using AtlasLMS.Shared.DTOs.Create;

using BlazorBootstrap;

using Microsoft.AspNetCore.Components;

namespace AtlasLMS.Blazor.Features.Authors.Pages;

public partial class AuthorMaintenanceCreate
{
    [Inject] public required IAuthorService AuthorService { get; set; }
    [Inject] public required ToastService ToastService { get; set; }
    [Inject] public required NavigationManager NavigationService { get; set; }

    private AuthorCreateDto author = new();
    private bool currentPost = false;

    #region Methods-------------------------------------------------------------------------------
    private void HandleCancel() => NavigationService.NavigateTo("/authors");
    private async Task HandleSaveAuthor(AuthorCreateDto author)
    {
        if (author == null) return;

        currentPost = true;

        await AuthorService.CreateAuthorAsync(author);
        ToastService.Notify(new(ToastType.Success, "¡Listo!", "Autor creado correctamente."));
        NavigationService.NavigateTo("/authors");

        currentPost = false;
    }
    #endregion
}
