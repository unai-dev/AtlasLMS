using AtlasLMS.Blazor.Features.Categories.Contracts;
using AtlasLMS.Blazor.Security.Contracts;
using AtlasLMS.Shared.DTOs.Read;

using BlazorBootstrap;

using Microsoft.AspNetCore.Components;

namespace AtlasLMS.Blazor.Features.Categories.Pages;

public partial class CategoriesPage
{
    [Inject] public required ToastService ToastService { get; set; }
    [Inject] public required ICategoryService CategoryService { get; set; }
    [Inject] public required NavigationManager NavigationService { get; set; }
    [Inject] public required IAtlasExceptionHandler AtlasExceptionHandler { get; set; }

    private List<CategoryReadDto> categories = new List<CategoryReadDto>();
    private ConfirmDialog dialog = default!;
    private bool isLoading = false;

    #region OnInitialized----------------------------------------------------------------
    protected override async Task OnInitializedAsync()
    {
        await RefreshCategories();
    }
    #endregion

    #region ButtonActions----------------------------------------------------------------
    private void HandleNewCategory() => NavigationService.NavigateTo("/categories/create");
    private async Task HandleDeleteCategory(int ID)
    {
        var confirm = await dialog.ShowAsync($"¿Esta seguro que desea eliminar este elemento?", "Esta acción no se puede deshacer.");
        if (confirm)
        {
            var response = await CategoryService.DeleteCategoryAsync(ID);
            if (response.IsSuccessStatusCode)
            {
                ToastService.Notify(new(ToastType.Success, "¡Listo!", "Categoría eliminada con exito"));
                await RefreshCategories();
                return;
            }

            await AtlasExceptionHandler.SwitchExceptionMessage(response);
        }
        return;
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
    }
    #endregion
}
