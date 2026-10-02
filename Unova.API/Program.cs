using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Scalar.AspNetCore;
using System.Text;
using Unova.API.Middlewares;
using Unova.App.Contracts;
using Unova.App.Services;
using Unova.Domain.Entities;
using Unova.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

#region BASE CONFIGURATION
builder.Services.AddControllers();
builder.Services.AddOpenApi();
#endregion

#region DB CONTEXT 
string sCS = builder.Configuration.GetConnectionString("UNOVA_CS")!;
builder.Services.AddDbContext<UnovaDbContext>(cfg => cfg.UseSqlServer(sCS));
#endregion

#region SERVICES
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<ILocationService, LocationService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IBookingService, BookingService>();
builder.Services.AddScoped<IAddressService, AddressService>();
builder.Services.AddScoped<ICenterService, CenterService>();
builder.Services.AddScoped<ICopyService, CopyService>();
builder.Services.AddScoped<IEnterpriseService, EnterpriseService>();
builder.Services.AddScoped<ILanguageService, LanguageService>();
#endregion

#region AUTOMAPPER 
builder.Services.AddAutoMapper(cfg => { }, typeof(Program));
#endregion

#region AUTH
builder.Services.AddIdentityCore<User>()
    //.AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<UnovaDbContext>()
    .AddDefaultTokenProviders()
    .AddSignInManager();
builder.Services.AddAuthentication().AddJwtBearer(cfg =>
{
    cfg.MapInboundClaims = false;
    cfg.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateAudience = false,
        ValidateIssuer = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["KEY_JWT"]!)),
        ClockSkew = TimeSpan.Zero
    };
});
builder.Services.AddAuthorization(opt =>
{
    opt.AddPolicy("admin", policy => policy.RequireClaim("admin"));
});
#endregion

#region CORS
builder.Services.AddCors(policy =>
{
    policy.AddDefaultPolicy(cfg =>
    {
        cfg.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
    });
});
#endregion

#region APP AND OPENAPI
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}
#endregion

#region MIDDLEWARES 
app.UseHttpsRedirection();
app.UseMiddleware<UnovaCatchMiddleware>();
app.MapControllers();
app.UseCors();
app.UseAuthentication();
app.UseAuthorization();
app.Run();
#endregion