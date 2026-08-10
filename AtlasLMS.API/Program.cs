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

// =======================================
// =========== BASE CONFIGURATION ========
// =======================================
builder.Services.AddControllers();
builder.Services.AddOpenApi();
// =======================================
// =============== DB CONTEXT ============
// =======================================
builder.Services.AddDbContext<AtlasDbContext>(cfg => cfg.UseSqlServer(builder.Configuration.GetConnectionString("LMS_CN")));

// =======================================
// ================ SERVICES =============
// =======================================
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<ILoanService, LoanService>();
builder.Services.AddScoped<ILocationService, LocationService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IBookingService, BookingService>();
// =======================================
// =============== AUTOMAPPER ============
// =======================================
builder.Services.AddAutoMapper(cfg => { }, typeof(Program));

// =======================================
// =============== AUTH ==================
// =======================================
builder.Services.AddIdentityCore<User>()
    .AddRoles<IdentityRole>()
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
// =======================================
// ================== CORS ===============
// =======================================
builder.Services.AddCors(policy =>
{
    policy.AddDefaultPolicy(cfg =>
    {
        cfg.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
    });
});
// =======================================
// =========== INITIALIZE APP ============
// =======================================
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

// =======================================
// =============== MIDDLEWARES ===========
// =======================================
app.UseHttpsRedirection();
app.UseMiddleware<CustomExceptionMiddleware>();
app.MapControllers();
app.UseCors();
app.UseAuthentication();
app.UseAuthorization();
app.Run();