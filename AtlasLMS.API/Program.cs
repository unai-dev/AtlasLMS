using AtlasLMS.API.Config;
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

// =======================================
// =============== AUTOMAPPER ============
// =======================================
builder.Services.AddAutoMapper(cfg => { }, typeof(Program));

// =======================================
// =============== AUTH ==================
// =======================================
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

// =======================================
// ================== CORS ===============
// =======================================
builder.Services.AddCors(policy =>
{
    policy.AddDefaultPolicy(cfg =>
    {
        cfg.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().AllowCredentials();
    });
});
// =======================================
// =========== INITIALIZE APP ============
// =======================================
var app = builder.Build();

// =======================================
// =============== MIDDLEWARES ===========
// =======================================
app.MapControllers();
app.UseCors();
app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();
app.Run();