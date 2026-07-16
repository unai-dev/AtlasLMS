using AtlasLMS.API.Data;
using AtlasLMS.API.Entities;
using AtlasLMS.API.Middleware;
using AtlasLMS.API.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// =======================================
// =========== BASE CONFIGURATION ========
// =======================================
builder.Services.AddControllers();

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
    opt.AddPolicy("ADMIN", policy => policy.RequireClaim("ADMIN"));
    opt.AddPolicy("CUSTOMER", policy => policy.RequireClaim("CUSTOMER"));
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

// =======================================
// =============== MIDDLEWARES ===========
// =======================================
app.UseMiddleware<CustomExceptionMiddleware>();
app.MapControllers();
app.UseCors();
app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();
app.Run();