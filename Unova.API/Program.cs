using System.Text;

using AtlasLMS.API.Middlewares;
using AtlasLMS.Application.Contracts;
using AtlasLMS.Application.Services;
using AtlasLMS.Data;
using AtlasLMS.Domain.Entities;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

#region BASE CONFIGURATION
builder.Services.AddControllers();
builder.Services.AddOpenApi();
#endregion

#region DB CONTEXT 
builder.Services.AddDbContext<AtlasDbContext>(cfg => cfg.UseSqlServer(builder.Configuration.GetConnectionString("LMS_CN")));
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
#endregion

#region AUTOMAPPER 
builder.Services.AddAutoMapper(cfg => { }, typeof(Program));
#endregion

#region AUTH
builder.Services.AddIdentityCore<User>()
    //.AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AtlasDbContext>()
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
app.UseMiddleware<AtlasCatchMiddleware>();
app.MapControllers();
app.UseCors();
app.UseAuthentication();
app.UseAuthorization();
app.Run();
#endregion