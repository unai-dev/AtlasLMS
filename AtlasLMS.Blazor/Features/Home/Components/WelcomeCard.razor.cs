using AtlasLMS.Shared.DTOs.Read;

using Microsoft.AspNetCore.Components;

namespace AtlasLMS.Blazor.Features.Home.Components;

public partial class WelcomeCard
{
    #region Parameters---------------------------------------------------------------
    [Parameter, EditorRequired] public bool IsLoading { get; set; }
    [Parameter, EditorRequired] public EventCallback OnLogout { get; set; }
    [Parameter, EditorRequired] public UserReadDto User { get; set; }
    #endregion
}
