using AtlasLMS.Application.Contracts;
using AtlasLMS.Domain.Entities;
using AtlasLMS.Domain.Exceptions;
using AtlasLMS.Shared.DTOs.Create;
using AtlasLMS.Shared.DTOs.Detail;
using AtlasLMS.Shared.DTOs.Read;

using AutoMapper;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AtlasLMS.Application.Services;

public class UserService : IUserService
{
    private readonly UserManager<User> _userManager;
    private readonly IMapper _mapper;

    public UserService(UserManager<User> userManager, IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UserReadDto>> GetUsersAsync()
    {
        var users = await _userManager.Users.ToListAsync();
        return _mapper.Map<IEnumerable<UserReadDto>>(users);
    }

    public async Task<UserReadDto> GetUserAsync(string ID)
    {
        if (string.IsNullOrWhiteSpace(ID))
            throw new BadRequestException($"El ID no puede estar vacio");
        var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id.Equals(ID))
            ?? throw new NotFoundException($"Usuario con ID {ID} no encontrado");
        return _mapper.Map<UserReadDto>(user);
    }

    public async Task<UserDetailDto> GetUserDetailAsync(string ID)
    {
        if (string.IsNullOrWhiteSpace(ID))
            throw new BadRequestException($"El ID no puede estar vacio");
        var user = await _userManager.Users
            .Include(x => x.Bookings)
            .Include(x => x.Loans)
            .FirstOrDefaultAsync(x => x.Id.Equals(ID))
            ?? throw new NotFoundException($"Usuario con ID {ID} no encontrado");
        return _mapper.Map<UserDetailDto>(user);
    }

    public async Task<UserReadDto> CreateUserAsync(UserCreateDto dto)
    {
        var existsEmail = await _userManager.FindByEmailAsync(dto.Email);
        if (existsEmail != null)
            throw new BadRequestException($"El email {dto.Email} ya pertenece a nuestro sistema");

        var existsCIF = await _userManager.Users.AnyAsync(x => x.CIF.Equals(dto.CIF));
        if (existsCIF)
            throw new BadRequestException($"El CIF {dto.CIF} ya pertenece a nuestro sistema");

        if (!string.IsNullOrEmpty(dto.UserName))
        {
            var existsUsername = await _userManager.Users.AnyAsync(x => x.UserName == dto.UserName);
            if (existsUsername)
                throw new BadRequestException($"El nombre de usuario {dto.UserName} ya esta ocupado");
        }

        dto.UserName = !string.IsNullOrEmpty(dto.UserName) ? dto.UserName : dto.Email.Split("@")[0];
        var user = _mapper.Map<User>(dto);
        await _userManager.CreateAsync(user, dto.Password);
        return _mapper.Map<UserReadDto>(user);
    }

    public async Task DeleteUserAsync(string ID)
    {
        if (string.IsNullOrWhiteSpace(ID))
            throw new BadRequestException($"El ID no puede estar vacio");
        var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id.Equals(ID))
            ?? throw new NotFoundException($"Usuario con ID {ID} no encontrado");
        await _userManager.DeleteAsync(user);
    }
}

