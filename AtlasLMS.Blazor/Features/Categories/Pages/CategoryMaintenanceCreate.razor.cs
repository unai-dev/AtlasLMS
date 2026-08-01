using AtlasLMS.Blazor.Features.Categories.Contracts;
using AtlasLMS.Shared.DTOs.Create;

using BlazorBootstrap;

using Microsoft.AspNetCore.Components;

namespace AtlasLMS.Blazor.Features.Categories.Pages;

public partial class CategoryMaintenanceCreate
{
    [Inject] public required ICategoryService CategoryService { get; set; }
    [Inject] public required ToastService ToastService { get; set; }
    [Inject] public required NavigationManager NavigationService { get; set; }

    private CategoryCreateDto category = new();
    private bool currentPost = false;

    #region Methods-----------------------------------------------------------------------------
    private void HandleCancel() => NavigationService.NavigateTo("/categories");
    private async Task HandleSaveCategory(CategoryCreateDto category)
    {
        if (category == null) return;

        currentPost = true;

        await CategoryService.CreateCategoryAsync(category);
        ToastService.Notify(new(ToastType.Success, "¡Listo!", "Categoría creada correctamente."));
        NavigationService.NavigateTo("/categories");

        currentPost = false;
    }
    #endregion
}
