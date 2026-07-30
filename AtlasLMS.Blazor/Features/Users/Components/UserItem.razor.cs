using AtlasLMS.Shared.DTOs.Read;

using Microsoft.AspNetCore.Components;

namespace AtlasLMS.Blazor.Features.Users.Components;

public partial class UserItem
{
    #region Parameters--------------------------------------------------------------
    [Parameter, EditorRequired] public UserReadDto User { get; set; }
    [Parameter] public EventCallback<string> OnView { get; set; }
    [Parameter] public EventCallback<string> OnEdit { get; set; }
    [Parameter] public EventCallback<string> OnDelete { get; set; }
    #endregion
}
