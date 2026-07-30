using AtlasLMS.Shared.DTOs.Read;

using Microsoft.AspNetCore.Components;

namespace AtlasLMS.Blazor.Features.Categories.Components;

public partial class CategoryItem
{
    #region Parameters-----------------------------------------------------
    [Parameter, EditorRequired] public CategoryReadDto Category { get; set; }
    [Parameter] public EventCallback<int> OnView { get; set; }
    [Parameter] public EventCallback<int> OnEdit { get; set; }
    [Parameter] public EventCallback<int> OnDelete { get; set; }
    #endregion
}
