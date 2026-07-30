using AtlasLMS.Shared.DTOs.Read;

using Microsoft.AspNetCore.Components;

namespace AtlasLMS.Blazor.Features.Authors.Components;

public partial class AuthorItem
{
    #region Parameters-----------------------------------------------------
    [Parameter, EditorRequired] public AuthorReadDto Author { get; set; }
    [Parameter] public EventCallback<int> OnView { get; set; }
    [Parameter] public EventCallback<int> OnEdit { get; set; }
    [Parameter] public EventCallback<int> OnDelete { get; set; }
    #endregion
}
