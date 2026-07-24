using AtlasLMS.Blazor;
using AtlasLMS.Blazor.Features.Auth.Contracts;
using AtlasLMS.Blazor.Features.Auth.Services;

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

await builder.Build().RunAsync();
