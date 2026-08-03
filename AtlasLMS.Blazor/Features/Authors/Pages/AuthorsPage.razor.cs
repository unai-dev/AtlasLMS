using AtlasLMS.Blazor.Features.Authors.Contracts;
using AtlasLMS.Blazor.Security.Contracts;
using AtlasLMS.Shared.DTOs.Read;

using BlazorBootstrap;

using Microsoft.AspNetCore.Components;

namespace AtlasLMS.Blazor.Features.Authors.Pages;

public partial class AuthorsPage
{
    [Inject] public required IAuthorService AuthorService { get; set; }
    [Inject] public required ToastService ToastService { get; set; }
    [Inject] public required NavigationManager NavigationService { get; set; }
    [Inject] public required IAtlasExceptionHandler AtlasExceptionHandler { get; set; }


    private List<AuthorReadDto> authors = new List<AuthorReadDto>();
    private ConfirmDialog dialog = default!;
    private bool isLoading = false;

    #region OnInitialized----------------------------------------------------------------
    protected override async Task OnInitializedAsync()
    {
        await RefreshAuthors();
    }
    #endregion

    #region ButtonActions----------------------------------------------------------------
    private void HandleAddAuthor() => NavigationService.NavigateTo("/authors/create");
    private async Task HandleDeleteAuthor(int ID)
    {
        var confirm = await dialog.ShowAsync($"¿Esta seguro que desea eliminar este elemento?", "Esta acción no se puede deshacer.");
        if (confirm)
        {
            var response = await AuthorService.DeleteAuthorAsync(ID);
            if (response.IsSuccessStatusCode)
            {
                ToastService.Notify(new(ToastType.Success, "¡Listo!", "Autor eliminado con exito"));
                await RefreshAuthors();
                return;
            }

            await AtlasExceptionHandler.SwitchExceptionMessage(response);
        }
        return;
    }
    #endregion

    #region Methods----------------------------------------------------------------------
    private async Task RefreshAuthors()
    {
        isLoading = true;
        authors = (await AuthorService.GetAuthorsAsync()).ToList();
        if (authors.Count == 0)
        {
            ToastService.Notify(new(ToastType.Info, "¡Info!", "No hay autores disponibles"));
            return;
        }

        isLoading = false;
    }
    #endregion
}
