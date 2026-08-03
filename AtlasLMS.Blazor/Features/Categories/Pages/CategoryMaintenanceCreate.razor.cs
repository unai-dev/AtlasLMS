using AtlasLMS.Blazor.Features.Categories.Contracts;
using AtlasLMS.Blazor.Security.Contracts;
using AtlasLMS.Shared.DTOs.Create;

using BlazorBootstrap;

using Microsoft.AspNetCore.Components;

namespace AtlasLMS.Blazor.Features.Categories.Pages;

public partial class CategoryMaintenanceCreate
{
    [Inject] public required ICategoryService CategoryService { get; set; }
    [Inject] public required ToastService ToastService { get; set; }
    [Inject] public required NavigationManager NavigationService { get; set; }
    [Inject] public required IAtlasExceptionHandler AtlasExceptionHandler { get; set; }

    private CategoryCreateDto category = new();
    private bool currentPost = false;

    #region Actions-----------------------------------------------------------------------------
    private void HandleCancel() => NavigationService.NavigateTo("/categories");
    private async Task HandleSaveCategory(CategoryCreateDto category)
    {
        currentPost = true;

        var response = await CategoryService.CreateCategoryAsync(category);
        currentPost = false;

        if (response.IsSuccessStatusCode)
        {
            ToastService.Notify(new(ToastType.Success, "¡Listo!", "Categoría creada correctamente."));
            NavigationService.NavigateTo("/categories");
            return;
        }

        await AtlasExceptionHandler.SwitchExceptionMessage(response);
    }
    #endregion
}
