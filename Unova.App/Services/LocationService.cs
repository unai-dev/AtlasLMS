using AutoMapper;

using Microsoft.EntityFrameworkCore;

namespace Unova.App.Services;

public class LocationService : ILocationService
{
    private readonly IMapper _mapper;
    private readonly UnovaDbContext _context;

    public LocationService(IMapper mapper, UnovaDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<IEnumerable<LocationReadDto>> GetAll()
    {
        var locations = await _context.Locations
            .AsNoTracking()
            .ToListAsync();
        return _mapper.Map<IEnumerable<LocationReadDto>>(locations);
    }

    public async Task<LocationReadDto> GetByID(int ID)
    {
        var location = await _context.Locations
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.ID == ID)
            ?? throw new NotFoundException($"La localizacion con ID {ID} no existe");
        return _mapper.Map<LocationReadDto>(location);
    }

    public async Task<LocationDetailDto> GetDetail(int ID)
    {
        var location = await _context.Locations
            .Include(x => x.Copies)
            .Include(x => x.Center)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.ID == ID)
            ?? throw new NotFoundException($"La ubicación con ID {ID} no existe");
        return _mapper.Map<LocationDetailDto>(location);
    }

    public async Task<LocationReadDto> Create(LocationCreateDto dto)
    {
        //Normalizamos para guardar unicamente en mayusculas
        dto.Shelf = dto.Shelf.ToUpper();
        dto.Column = dto.Column.ToUpper();
        dto.Aisle = dto.Aisle.ToUpper();

        //Si la localizacion concatenando, pasillo, columna y estante existe, lanzamos badrequest
        var existsLocation = await _context.Locations.AnyAsync(
            x => x.Column.Equals(dto.Column) &&
            x.Shelf.Equals(dto.Shelf) &&
            x.Aisle.Equals(dto.Aisle));
        if (existsLocation)
            throw new BadRequestException($"Ya existe la localizacion introducida");

        var location = _mapper.Map<Location>(dto);
        _context.Add(location);
        await _context.SaveChangesAsync();
        return _mapper.Map<LocationReadDto>(location);
    }

    public async Task Delete(int ID)
    {
        var location = await _context.Locations.FirstOrDefaultAsync(x => x.ID == ID)
            ?? throw new NotFoundException($"La localizacion con ID {ID} no existe");

        _context.Remove(location);
        await _context.SaveChangesAsync();
    }
}