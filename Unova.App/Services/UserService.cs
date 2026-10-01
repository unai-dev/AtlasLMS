using AutoMapper;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using Unova.App.Contracts;
using Unova.Domain;
using Unova.Domain.Entities;
using Unova.Infrastructure;
using Unova.Shared.DTOs.Create;
using Unova.Shared.DTOs.Detail;
using Unova.Shared.DTOs.Read;
using Unova.Shared.DTOs.Update;

namespace Unova.App.Services;

public class UserService : IUserService
{
    private readonly UserManager<User> _userManager;
    private readonly IMapper _mapper;
    private readonly IHttpContextAccessor _accessor;
    private readonly UnovaDbContext _context;

    public UserService(UserManager<User> userManager, IMapper mapper, IHttpContextAccessor accessor, UnovaDbContext context)
    {
        _userManager = userManager;
        _mapper = mapper;
        _accessor = accessor;
        _context = context;
    }

    public async Task<IEnumerable<UserReadDto>> GetAll()
    {
        var users = await _userManager.Users
            .AsNoTracking()
            .ToListAsync();
        return _mapper.Map<IEnumerable<UserReadDto>>(users);
    }

    public async Task<UserReadDto> GetByID(int ID)
    {
        var user = await _userManager.FindByIdAsync(ID.ToString())
            ?? throw new NotFoundException($"Usuario con ID {ID} no encontrado");
        return _mapper.Map<UserReadDto>(user);
    }

    public async Task<UserDetailDto> GetDetail(int ID)
    {
        var user = await _userManager.Users
            .Include(x => x.Bookings)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == ID)
            ?? throw new NotFoundException($"Usuario con ID {ID} no encontrado");

        return _mapper.Map<UserDetailDto>(user);
    }

    public async Task<UserDetailDto> GetMe()
    {
        var claim = _accessor.HttpContext?.User.Claims.FirstOrDefault(x => x.Type == "email")
            ?? throw new BadRequestException("Error al claim de  usuario");

        var user = await _userManager.Users
            .Include(x => x.Library)
            .Include(x => x.Bookings)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Email == claim.Value);
        return _mapper.Map<UserDetailDto>(user);
    }

    public async Task<UserReadDto> Create(UserCreateDto dto)
    {
        var existsEmail = await _userManager.FindByEmailAsync(dto.Email);
        if (existsEmail is not null)
            throw new BadRequestException($"El email {dto.Email} ya pertenece a nuestro sistema");

        var existsCIF = await _userManager.Users.AnyAsync(x => x.CIF.Equals(dto.CIF));
        if (existsCIF)
            throw new BadRequestException($"El CIF {dto.CIF} ya pertenece a nuestro sistema");

        //Si existe un usuario con el mismo nickname, lanzamos badrequest
        if (!string.IsNullOrEmpty(dto.UserName))
        {
            var existsUsername = await _userManager.Users.AnyAsync(x => x.UserName!.Equals(dto.UserName));
            if (existsUsername)
                throw new BadRequestException($"El nombre de usuario {dto.UserName} ya esta ocupado");
        }

        //Si el DTO no contiene el nombre de usuario, guardamos la primera parte del email(unai@gmail.com) => unai
        dto.UserName = !string.IsNullOrEmpty(dto.UserName) ? dto.UserName : dto.Email.Split("@")[0];

        var user = _mapper.Map<User>(dto);
        await _userManager.CreateAsync(user, dto.Password);
        return _mapper.Map<UserReadDto>(user);
    }

    public async Task<UserReadDto> UpdateUserAsync(int ID, UserUpdateDto dto)
    {
        var user = await _userManager.FindByIdAsync(ID.ToString())
            ?? throw new NotFoundException($"Usuario con ID {ID} no encontrado");

        //Si el Email ya consta en nuestra base de datos, lanzamos badrequest
        if (!string.IsNullOrEmpty(dto.Email))
        {
            var existsEmail = await _userManager.FindByEmailAsync(dto.Email!);
            if (existsEmail is not null && existsEmail.Id != ID)
                throw new BadRequestException($"El email {dto.Email} ya pertenece a nuestro sistema");
        }

        //Si el CIF ya consta en nuestra base de datos, lanzamos badrequest
        if (!string.IsNullOrEmpty(dto.CIF))
        {
            var existsCIF = await _userManager.Users.AnyAsync(x => x.CIF.Equals(dto.CIF) && x.Id != ID);
            if (existsCIF)
                throw new BadRequestException($"El CIF {dto.CIF} ya pertenece a nuestro sistema");
        }

        //Si existe un usuario con el mismo nickname, lanzamos badrequest
        if (!string.IsNullOrEmpty(dto.UserName))
        {
            var existsUsername = await _userManager.Users.AnyAsync(x => x.UserName!.Equals(dto.UserName) && x.Id != ID);
            if (existsUsername)
                throw new BadRequestException($"El nombre de usuario {dto.UserName} ya esta ocupado");
        }

        //Si el DTO no tiene la informacion, guardamos el valor anterior
        user.Email = dto.Email ?? user.Email;
        user.CIF = dto.CIF ?? user.CIF;
        user.UserName = dto.UserName ?? user.UserName;

        user.UpdatedAt = DateTime.UtcNow;

        await _userManager.UpdateAsync(user);
        return _mapper.Map<UserReadDto>(user);
    }

    public async Task Delete(int ID)
    {
        var user = await _userManager.FindByIdAsync(ID.ToString())
            ?? throw new NotFoundException($"Usuario con ID {ID} no encontrado");

        var userHasAnyBooking = await _context.Bookings.AnyAsync(x => x.UserID == ID && x.Status == EBookingStatus.Active);
        if (userHasAnyBooking)
            throw new BadRequestException($"El usuario no puede ser eliminado. Tiene reservas activas");

        await _userManager.DeleteAsync(user);
    }
}

