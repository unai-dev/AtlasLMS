using AutoMapper;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using Unova.Domain;

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
            .Include(x => x.Enterprise)
            .Include(x => x.Bookings)
            .Include(x => x.Center)
            .Include(x => x.Language)
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

        var enterprise = await _context.Enterprises
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.ID == dto.EnterpriseID)
            ?? throw new NotFoundException($"La empreas {dto.EnterpriseID} no existe");

        var existsCenter = await _context.Centers.AnyAsync(x => x.ID == dto.CenterID && x.EnterpriseID == enterprise.ID);
        if (!existsCenter)
            throw new NotFoundException($"El centro {dto.CenterID} no figura en la empresa");

        var existsLanguage = await _context.Languages.AnyAsync(x => x.ID == dto.LanguageID);
        if (!existsLanguage)
            throw new NotFoundException($"El lenguaje {dto.LanguageID} no existe");

        var user = _mapper.Map<User>(dto);
        await _userManager.CreateAsync(user, dto.Password);
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

