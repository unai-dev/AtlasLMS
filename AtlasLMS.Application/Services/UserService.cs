using AtlasLMS.Application.Contracts;
using AtlasLMS.Domain.Entities;
using AtlasLMS.Domain.Exceptions;
using AtlasLMS.Shared.DTOs.Create;
using AtlasLMS.Shared.DTOs.Detail;
using AtlasLMS.Shared.DTOs.Read;
using AtlasLMS.Shared.DTOs.Update;

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
        var user = await _userManager.FindByIdAsync(ID)
            ?? throw new NotFoundException($"Usuario con ID {ID} no encontrado");
        return _mapper.Map<UserReadDto>(user);
    }

    public async Task<UserDetailDto> GetUserLoansAsync(string ID)
    {
        var user = await _userManager.Users
            .Where(x => x.Id.Equals(ID))
            .Select(x => x.Loans)
            .ToListAsync();
        return _mapper.Map<UserDetailDto>(user);
    }
    public async Task<UserDetailDto> GetUserBookingsAsync(string ID)
    {
        var user = await _userManager.Users
            .Where(x => x.Id.Equals(ID))
            .Select(x => x.Bookings)
            .ToListAsync();
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
            var existsUsername = await _userManager.Users.AnyAsync(x => x.UserName!.Equals(dto.UserName));
            if (existsUsername)
                throw new BadRequestException($"El nombre de usuario {dto.UserName} ya esta ocupado");
        }

        dto.UserName = !string.IsNullOrEmpty(dto.UserName) ? dto.UserName : dto.Email.Split("@")[0];
        var user = _mapper.Map<User>(dto);
        await _userManager.CreateAsync(user, dto.Password);
        return _mapper.Map<UserReadDto>(user);
    }

    public async Task<UserReadDto> UpdateUserAsync(string ID, UserUpdateDto dto)
    {
        var user = await _userManager.FindByIdAsync(ID)
            ?? throw new NotFoundException($"Usuario con ID {ID} no encontrado");

        if (!string.IsNullOrEmpty(dto.Email))
        {
            var existsEmail = await _userManager.FindByEmailAsync(dto.Email);
            if (existsEmail != null && existsEmail.Id != ID)
                throw new BadRequestException($"El email {dto.Email} ya pertenece a nuestro sistema");
        }

        if (!string.IsNullOrEmpty(dto.CIF))
        {
            var existsCIF = await _userManager.Users.AnyAsync(x => x.CIF.Equals(dto.CIF) && x.Id != ID);
            if (existsCIF)
                throw new BadRequestException($"El CIF {dto.CIF} ya pertenece a nuestro sistema");
        }

        if (!string.IsNullOrEmpty(dto.UserName))
        {
            var existsUsername = await _userManager.Users.AnyAsync(x => x.UserName!.Equals(dto.UserName) && x.Id != ID);
            if (existsUsername)
                throw new BadRequestException($"El nombre de usuario {dto.UserName} ya esta ocupado");
        }

        user.Email = !string.IsNullOrEmpty(dto.Email) ? dto.Email : user.Email;
        user.CIF = !string.IsNullOrEmpty(dto.CIF) ? dto.CIF : user.CIF;
        user.UserName = !string.IsNullOrEmpty(dto.UserName) ? dto.UserName : user.UserName;
        user.NormalizedEmail = user.Email?.Normalize();
        user.NormalizedUserName = user.UserName?.Normalize();

        user.UpdatedAt = DateTime.UtcNow;

        await _userManager.UpdateAsync(user);
        return _mapper.Map<UserReadDto>(user);
    }

    public async Task DeleteUserAsync(string ID)
    {
        var user = await _userManager.FindByIdAsync(ID)
            ?? throw new NotFoundException($"Usuario con ID {ID} no encontrado");
        await _userManager.DeleteAsync(user);
    }
}

