using AtlasLMS.Shared.DTOs.Read;

using Microsoft.AspNetCore.Components;

namespace AtlasLMS.Blazor.Features.Books.Components;

public partial class BookItem
{
    #region Parameters-----------------------------------------------------
    [Parameter, EditorRequired] public BookReadDto Book { get; set; }
    [Parameter] public EventCallback<int> OnView { get; set; }
    [Parameter] public EventCallback<int> OnEdit { get; set; }
    [Parameter] public EventCallback<int> OnDelete { get; set; }
    #endregion
}
