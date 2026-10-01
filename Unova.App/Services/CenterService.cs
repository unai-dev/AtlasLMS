using AutoMapper;

using Microsoft.EntityFrameworkCore;

using Unova.App.Contracts;
using Unova.Domain.Entities;
using Unova.Infrastructure;
using Unova.Shared.DTOs.Create;
using Unova.Shared.DTOs.Detail;
using Unova.Shared.DTOs.Read;

namespace Unova.App.Services;

public class CenterService : ICenterService
{
    private readonly IUserService _userService;
    private readonly UnovaDbContext _context;
    private readonly IMapper _mapper;

    public CenterService(IUserService userService, UnovaDbContext context, IMapper mapper)
    {
        _userService = userService;
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CenterReadDto>> GetAll()
    {
        var currentUser = await _userService.GetMe();
        var libraryID = currentUser.LibraryID;

        var centers = await _context.Centers
            .Where(x => x.LibraryID == libraryID)
            .AsNoTracking()
            .ToListAsync();
        return _mapper.Map<IEnumerable<CenterReadDto>>(centers);
    }
    public async Task<CenterReadDto> GetByID(int ID)
    {
        var center = await _context.Centers
             .AsNoTracking()
             .FirstOrDefaultAsync(x => x.ID == ID)
             ?? throw new NotFoundException($"Center with ID {ID} not found.");

        return _mapper.Map<CenterReadDto>(center);
    }

    public async Task<CenterDetailDto> GetDetail(int ID)
    {
        var center = await _context.Centers
            .Include(x => x.Library)
            .Include(x => x.Books)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.ID == ID)
            ?? throw new NotFoundException($"Center with ID {ID} not found.");

        return _mapper.Map<CenterDetailDto>(center);
    }

    public async Task<CenterReadDto> Create(CenterCreateDto dto)
    {
        var currentUser = await _userService.GetMe();
        var libraryID = currentUser.LibraryID;

        var exists = await _context.Centers
            .Where(x => x.LibraryID == libraryID)
            .AnyAsync(x => x.Name.Equals(dto.Name));

        if (exists)
            throw new BadRequestException($"The center already exists in current library");

        var center = _mapper.Map<Center>(dto);

        _context.Centers.Add(center);
        await _context.SaveChangesAsync();
        return _mapper.Map<CenterReadDto>(center);
    }

    public async Task Delete(int ID)
    {
        var center = await _context.Centers
             .FirstOrDefaultAsync(x => x.ID == ID)
             ?? throw new NotFoundException($"Center with ID {ID} not found.");

        _context.Centers.Remove(center);
        await _context.SaveChangesAsync();
    }
}
