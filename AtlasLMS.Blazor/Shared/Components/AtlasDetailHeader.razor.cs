using Microsoft.AspNetCore.Components;

namespace AtlasLMS.Blazor.Shared.Components;

public partial class AtlasDetailHeader
{

    #region Parameters--------------------------------------------------------------
    [Parameter, EditorRequired] public string HeaderText { get; set; }
    [Parameter, EditorRequired] public EventCallback OnReturn { get; set; }
    #endregion
}
