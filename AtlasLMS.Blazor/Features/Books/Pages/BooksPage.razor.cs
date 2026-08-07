using AtlasLMS.Blazor.Features.Books.Contracts;
using AtlasLMS.Blazor.Security.Contracts;
using AtlasLMS.Shared.DTOs.Read;

using BlazorBootstrap;

using Microsoft.AspNetCore.Components;

namespace AtlasLMS.Blazor.Features.Books.Pages;

public partial class BooksPage
{
    [Inject] public required IBookService BookService { get; set; }
    [Inject] public required ToastService ToastService { get; set; }
    [Inject] public required NavigationManager NavigationService { get; set; }
    [Inject] public required IAtlasExceptionHandler AtlasExceptionHandler { get; set; }

    private List<BookReadDto> books = new List<BookReadDto>();
    private ConfirmDialog dialog = default!;
    private bool isLoading = false;

    #region OnInitialized----------------------------------------------------------------
    protected override async Task OnInitializedAsync()
    {
        await RefreshBooks();
    }
    #endregion

    #region ButtonActions----------------------------------------------------------------
    private void HandleAddBook() => NavigationService.NavigateTo("/books/create");
    private void HandleViewBook(int ID) => NavigationService.NavigateTo($"/books/{ID}");
    private async Task HandleDeleteBook(int ID)
    {
        var confirm = await dialog.ShowAsync($"¿Esta seguro que desea eliminar este elemento?", "Esta acción no se puede deshacer.");
        if (confirm)
        {
            var response = await BookService.DeleteBookAsync(ID);
            if (response.IsSuccessStatusCode)
            {
                ToastService.Notify(new(ToastType.Success, "¡Listo!", "Libro eliminado con exito"));
                await RefreshBooks();
                return;
            }
            await AtlasExceptionHandler.SwitchExceptionMessage(response);
        }
        return;
    }
    #endregion

    #region Methods----------------------------------------------------------------------
    private async Task RefreshBooks()
    {
        isLoading = true;
        books = (await BookService.GetBooksAsync()).ToList();
        if (books.Count == 0)
        {
            ToastService.Notify(new(ToastType.Info, "¡Info!", "No hay libros disponibles"));
            return;
        }
        isLoading = false;
    }
    #endregion
}
