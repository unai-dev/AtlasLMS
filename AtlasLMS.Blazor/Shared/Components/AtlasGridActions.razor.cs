using Microsoft.AspNetCore.Components;

namespace AtlasLMS.Blazor.Shared.Components;

public partial class AtlasGridActions<TID>
{
    #region Parameters-----------------------------------------------------------------
    [Parameter] public TID? ID { get; set; }
    [Parameter] public bool ShowView { get; set; } = true;
    [Parameter] public bool ShowDelete { get; set; } = true;
    [Parameter] public bool ShowEdit { get; set; } = true;
    [Parameter] public EventCallback<TID> OnDelete { get; set; }
    [Parameter] public EventCallback<TID> OnView { get; set; }
    [Parameter] public EventCallback<TID> OnEdit { get; set; }
    #endregion
}
