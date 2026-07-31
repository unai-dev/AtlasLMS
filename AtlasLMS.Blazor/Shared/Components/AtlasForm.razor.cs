using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace AtlasLMS.Blazor.Shared.Components;

public partial class AtlasForm<TModel>
{
    #region Parameters---------------------------------------------------------
    [Parameter, EditorRequired] public TModel Model { get; set; }
    [Parameter, EditorRequired] public EventCallback<TModel> OnSave { get; set; }
    [Parameter, EditorRequired] public EventCallback OnCancel { get; set; }
    [Parameter, EditorRequired] public RenderFragment ChildContent { get; set; }
    [Parameter, EditorRequired] public string CaptionMaintenance { get; set; }
    [Parameter, EditorRequired] public bool CurrentPost { get; set; }
    #endregion

    private EditContext? editContext;

    #region OnInitialized-------------------------------------------------
    protected override void OnInitialized()
    {
        editContext = new EditContext(Model);
    }
    #endregion

    #region ButtonActions----------------------------------------------------------
    private async Task HandleValidSubmit()
    {
        if (editContext is not null && editContext.Validate())
            await OnSave.InvokeAsync(Model);
    }
    #endregion
}
