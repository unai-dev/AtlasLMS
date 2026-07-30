using System.Net;
using System.Net.Http.Json;

using AtlasLMS.Shared.DTOs.Read;
using AtlasLMS.Shared.Responses;

using BlazorBootstrap;

namespace AtlasLMS.Blazor.Features.Authors.Pages;

public partial class AuthorsPage
{
    private List<AuthorReadDto>? authors;
    private bool isLoading = false;

    #region OnInitialized----------------------------------------------------------------
    protected override async Task OnInitializedAsync()
    {
        await RefreshAuthors();
    }
    #endregion

    #region ButtonActions----------------------------------------------------------------
    private async Task HandleDeleteAuthor(int ID)
    {
        var response = await AuthorService.DeleteAuthorAsync(ID);
        if (response.IsSuccessStatusCode)
        {
            ToastService.Notify(new(ToastType.Success, "¡Listo!", "Autor eliminado con exito"));
            await RefreshAuthors();
            return;
        }

        await SwitchExceptionMessage(response);
    }
    #endregion

    #region Methods----------------------------------------------------------------------
    private async Task RefreshAuthors()
    {
        isLoading = true;
        authors = (await AuthorService.GetAuthorsAsync()).ToList();
        isLoading = false;
        if (authors.Count == 0)
        {
            ToastService.Notify(new(ToastType.Info, "¡Info!", "No hay autores disponibles"));
            return;
        }
        ToastService.Notify(new(ToastType.Success, "¡Info!", "Autores cargados correctamente"));
    }

    private async Task SwitchExceptionMessage(HttpResponseMessage response)
    {

        var exceptionResponse = await response.Content.ReadFromJsonAsync<MiddlewareExceptionResponse>();
        if (exceptionResponse is null) return;
        switch (response.StatusCode)
        {
            case HttpStatusCode.NotFound:
                ToastService.Notify(new(ToastType.Success, "¡Error!", exceptionResponse.Message));
                break;
            case HttpStatusCode.BadRequest:
                ToastService.Notify(new(ToastType.Success, "¡Error!", exceptionResponse.Message));
                break;
            default:
                ToastService.Notify(new(ToastType.Success, "¡Error!", exceptionResponse.Message));
                break;
        }
    }
    #endregion
}
