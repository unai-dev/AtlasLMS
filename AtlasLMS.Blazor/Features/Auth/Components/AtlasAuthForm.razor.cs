using AtlasLMS.Shared.DTOs.Auth;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace AtlasLMS.Blazor.Features.Auth.Components;

public partial class AtlasAuthForm
{
    #region Parameters-----------------------------------------------------
    [Parameter, EditorRequired] public LoginDto User { get; set; }
    [Parameter, EditorRequired] public EventCallback OnSubmit { get; set; }
    [Parameter, EditorRequired] public bool CurrentPost { get; set; }
    #endregion

    private EditContext? editContext;
    private bool hidePassword = true;

    #region OnInitialized-------------------------------------------------------------
    protected override void OnInitialized() => editContext = new EditContext(User);
    #endregion

    #region Methods-------------------------------------------------------------------
    private void TooglePassword() => hidePassword = !hidePassword;

    private async Task HandleValidSubmit()
    {
        if (editContext is not null && editContext.Validate())
            await OnSubmit.InvokeAsync();
    }
    #endregion
}
