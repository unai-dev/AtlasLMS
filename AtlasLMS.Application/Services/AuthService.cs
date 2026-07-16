using AtlasLMS.Application.Contracts;
using AtlasLMS.Application.DTOs;
using AtlasLMS.Application.DTOs.Create;
using AtlasLMS.Domain.Entities;
using AtlasLMS.Domain.Exceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AtlasLMS.Application.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly IConfiguration _configuration;

    public AuthService(UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration configuration)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _configuration = configuration;
    }

    public async Task<AuthResponseDto> Register(UserCreateDto dto)
    {
        var emailUnique = await _userManager.FindByEmailAsync(dto.Email);
        if (emailUnique is not null)
        {
            throw new BadRequestException("Este email ya consta en nuestra base de datos");
        }

        var user = new User
        {
            UserName = string.IsNullOrEmpty(dto.UserName) ? dto.Email.Split("@")[0] : dto.UserName,
            Email = dto.Email
        };

        var result = await _userManager.CreateAsync(user, dto.Password!);
        return await GetJwtToken(dto.Email);
    }

    public async Task<AuthResponseDto> Login(UserCreateDto dto)
    {
        var user = await _userManager.FindByEmailAsync(dto.Email) ?? throw new NotFoundException("El usuario no exite");
        var result = await _signInManager.CheckPasswordSignInAsync(user, dto.Password!, false);

        if (!result.Succeeded)
        {
            throw new BadRequestException("La contraseña proporcionada no es valida");
        }

        return await GetJwtToken(dto.Email);
    }

    private async Task<AuthResponseDto> GetJwtToken(string email)
    {
        var claims = new List<Claim> { new Claim("email", email) };

        var user = await _userManager.FindByEmailAsync(email) ?? throw new BadRequestException("Este mail no existe en nuestra base de datos");
        var claimsDB = await _userManager.GetClaimsAsync(user);
        claims.AddRange(claimsDB);

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["KEY_JWT"]!));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var expiration = DateTime.Now.AddHours(1);

        var securityKey = new JwtSecurityToken(
            issuer: null,
            audience: null,
            expires: expiration,
            signingCredentials: credentials,
            claims: claims
            );

        var generatedToken = new JwtSecurityTokenHandler().WriteToken(securityKey);

        return new AuthResponseDto { Token = generatedToken, Expiration = expiration };

    }
}
