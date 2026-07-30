using System.Net;
using System.Net.Http.Json;

using AtlasLMS.Blazor.Features.Categories.Contracts;
using AtlasLMS.Shared.DTOs.Read;
using AtlasLMS.Shared.Responses;

using BlazorBootstrap;

using Microsoft.AspNetCore.Components;

namespace AtlasLMS.Blazor.Features.Categories.Pages;

public partial class CategoriesPage
{
    [Inject] public required ToastService ToastService { get; set; }
    [Inject] public required ICategoryService CategoryService { get; set; }

    private List<CategoryReadDto> categories = new List<CategoryReadDto>();
    private bool isLoading = false;

    #region OnInitialized----------------------------------------------------------------
    protected override async Task OnInitializedAsync()
    {
        await RefreshCategories();
    }
    #endregion

    #region ButtonActions----------------------------------------------------------------
    private async Task HandleDeleteCategory(int ID)
    {
        var response = await CategoryService.DeleteCategoryAsync(ID);
        if (response.IsSuccessStatusCode)
        {
            ToastService.Notify(new(ToastType.Success, "¡Listo!", "Categoría eliminada con exito"));
            await RefreshCategories();
            return;
        }

        await SwitchExceptionMessage(response);
    }
    #endregion

    #region Methods----------------------------------------------------------------------
    private async Task RefreshCategories()
    {
        isLoading = true;
        categories = (await CategoryService.GetCategoriesAsync()).ToList();
        isLoading = false;
        if (categories.Count == 0)
        {
            ToastService.Notify(new(ToastType.Info, "¡Info!", "No hay categorias disponibles"));
            return;
        }
        ToastService.Notify(new(ToastType.Success, "¡Listo!", "Categorias cargadas correctamente"));
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
