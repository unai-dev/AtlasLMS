using AutoMapper;

using Microsoft.EntityFrameworkCore;

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
        var enterpriseID = currentUser.EnterpriseID;

        var centers = await _context.Centers
            .Where(x => x.EnterpriseID == enterpriseID)
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
            .Include(x => x.Enterprise)
            .Include(x => x.Copies)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.ID == ID)
            ?? throw new NotFoundException($"Center with ID {ID} not found.");

        return _mapper.Map<CenterDetailDto>(center);
    }

    public async Task<CenterReadDto> Create(CenterCreateDto dto)
    {
        var currentUser = await _userService.GetMe();
        var enterpriseID = currentUser.EnterpriseID;

        var exists = await _context.Centers
            .Where(x => x.EnterpriseID == enterpriseID)
            .AnyAsync(x => x.Name.Equals(dto.Name));

        if (exists)
            throw new BadRequestException($"The center already exists in current enterprise");

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
