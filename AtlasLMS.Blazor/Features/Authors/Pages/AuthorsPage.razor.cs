using System.Net;
using System.Net.Http.Json;

using AtlasLMS.Blazor.Features.Authors.Contracts;
using AtlasLMS.Shared.DTOs.Read;
using AtlasLMS.Shared.Responses;

using BlazorBootstrap;

using Microsoft.AspNetCore.Components;

namespace AtlasLMS.Blazor.Features.Authors.Pages;

public partial class AuthorsPage
{
    [Inject] public required IAuthorService AuthorService { get; set; }
    [Inject] public required ToastService ToastService { get; set; }

    private List<AuthorReadDto> authors = new List<AuthorReadDto>();
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
            case HttpStatusCode.BadRequest:
            case HttpStatusCode.InternalServerError:
                ToastService.Notify(new(ToastType.Success, "¡Error!", exceptionResponse.Message));
                break;
        }
    }
    #endregion
}
