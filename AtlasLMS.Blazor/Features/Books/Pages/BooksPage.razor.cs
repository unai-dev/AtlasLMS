using System.Net;
using System.Net.Http.Json;

using AtlasLMS.Blazor.Features.Books.Contracts;
using AtlasLMS.Shared.DTOs.Read;
using AtlasLMS.Shared.Responses;

using BlazorBootstrap;

using Microsoft.AspNetCore.Components;

namespace AtlasLMS.Blazor.Features.Books.Pages;

public partial class BooksPage
{
    [Inject] public required IBookService BookService { get; set; }
    [Inject] public required ToastService ToastService { get; set; }

    private List<BookReadDto> books = new List<BookReadDto>();
    private bool isLoading = false;

    #region OnInitialized----------------------------------------------------------------
    protected override async Task OnInitializedAsync()
    {
        await RefreshBooks();
    }
    #endregion

    #region ButtonActions----------------------------------------------------------------
    private async Task HandleDeleteBook(int ID)
    {
        var response = await BookService.DeleteBookAsync(ID);
        if (response.IsSuccessStatusCode)
        {
            ToastService.Notify(new(ToastType.Success, "¡Listo!", "Libro eliminado con exito"));
            await RefreshBooks();
            return;
        }

        await SwitchExceptionMessage(response);
    }
    #endregion

    #region Methods----------------------------------------------------------------------
    private async Task RefreshBooks()
    {
        isLoading = true;
        books = (await BookService.GetBooksAsync()).ToList();
        isLoading = false;
        if (books.Count == 0)
        {
            ToastService.Notify(new(ToastType.Info, "¡Info!", "No hay libros disponibles"));
            return;
        }
        ToastService.Notify(new(ToastType.Success, "¡Listo!", "Libros cargados correctamente"));
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
                ToastService.Notify(new(ToastType.Success, "¡Error!", exceptionResponse.Message));
                break;
        }
    }
    #endregion
}
