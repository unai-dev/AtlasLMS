using AtlasLMS.Blazor;
using AtlasLMS.Blazor.Features.Auth.Contracts;
using AtlasLMS.Blazor.Features.Auth.Services;
using AtlasLMS.Blazor.Features.Users.Contracts;
using AtlasLMS.Blazor.Features.Users.Services;
using AtlasLMS.Blazor.Shared.Contracts;
using AtlasLMS.Blazor.Shared.Services;

using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// =======================================
// ================ SERVICES =============
// =======================================
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:6600/api/") });
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ILocalStorageService, LocalStorageService>();

await builder.Build().RunAsync();
