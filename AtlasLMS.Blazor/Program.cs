using AtlasLMS.Blazor;
using AtlasLMS.Blazor.Features.Auth.Contracts;
using AtlasLMS.Blazor.Features.Auth.Services;
using AtlasLMS.Blazor.Features.Authors.Contracts;
using AtlasLMS.Blazor.Features.Authors.Services;
using AtlasLMS.Blazor.Features.Users.Contracts;
using AtlasLMS.Blazor.Features.Users.Services;
using AtlasLMS.Blazor.Security.Contracts;
using AtlasLMS.Blazor.Security.Services;

using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// =======================================
// ================ SERVICES =============
// =======================================
builder.Services.AddAuthorizationCore();
builder.Services.AddBlazorBootstrap();
builder.Services.AddScoped<AuthHeaderHandler>();
builder.Services.AddHttpClient("AtlasAPI", client =>
{
    client.BaseAddress = new Uri("https://localhost:6600/api/");
}).AddHttpMessageHandler<AuthHeaderHandler>();

builder.Services.AddScoped(sp =>
    sp.GetRequiredService<IHttpClientFactory>().CreateClient("AtlasAPI"));

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<ILocalStorageService, LocalStorageService>();

await builder.Build().RunAsync();
