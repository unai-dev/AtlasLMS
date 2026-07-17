using AtlasLMS.Application.Contracts;
using AtlasLMS.Data;
using AtlasLMS.Domain.Entities;
using AtlasLMS.Domain.Exceptions;
using AtlasLMS.Shared.DTOs.Create;
using AtlasLMS.Shared.DTOs.Read;

using AutoMapper;

using Microsoft.EntityFrameworkCore;

namespace AtlasLMS.Application.Services;

public class LocationService : ILocationService
{
    private readonly IMapper _mapper;
    private readonly AtlasDbContext _context;

    public LocationService(IMapper mapper, AtlasDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    //Obtener todas las ubicaciones de la libreria 
    public async Task<IEnumerable<LocationReadDto>> GetLocationsAsync()
    {
        var locations = await _context.Locations.ToListAsync();
        return _mapper.Map<IEnumerable<LocationReadDto>>(locations);
    }
    //Obtener una ubicacion completa
    public async Task<LocationReadDto> GetLocationAsync(int ID)
    {
        var location = await _context.Locations.FirstOrDefaultAsync(x => x.ID == ID)
            ?? throw new NotFoundException($"La localizacion {ID} no existe");
        return _mapper.Map<LocationReadDto>(location);
    }
    //Obtener pasillos
    public async Task<IEnumerable<string>> GetAislesAsync()
    {
        var aisles = await _context.Locations.Select(x => x.Aisle).Distinct().ToListAsync();
        return aisles;
    }
    //Obtener columnas del pasillo indicado
    public async Task<IEnumerable<string>> GetColumnsByAisleAsync(string aisle)
    {
        aisle = aisle.Trim().ToUpper();
        var columns = await _context.Locations
            .Where(x => x.Aisle.ToUpper() == aisle)
            .Select(x => x.Column)
            .Distinct()
            .ToListAsync();
        return columns;
    }
    //Obtener los estantes de la columna y fila indicada
    public async Task<IEnumerable<string>> GetShelvesAsync(string aisle, string column)
    {
        aisle = aisle.Trim().ToUpper();
        column = column.Trim().ToUpper();
        var shelves = await _context.Locations
            .Where(x => x.Aisle.ToUpper() == aisle && x.Column.ToUpper() == column)
            .Select(x => x.Shelf)
            .Distinct()
            .ToListAsync();
        return shelves;
    }
    //Crear localizacion
    public async Task<LocationReadDto> CreateLocationAsync(LocationCreateDto dto)
    {
        //Validar si existe la ubicacion
        var existsLocation = await _context.Locations.AnyAsync(
            x => x.Column == dto.Column &&
            x.Shelf == dto.Shelf &&
            x.Aisle == dto.Aisle);
        if (existsLocation)
            throw new BadRequestException($"Ya existe la localizacion introducida");

        var location = _mapper.Map<Location>(dto);
        _context.Add(location);
        await _context.SaveChangesAsync();
        return _mapper.Map<LocationReadDto>(location);
    }
    //Eliminar localizacion
    public async Task DeleteLocationAsync(int ID)
    {
        var location = await _context.Locations.FirstOrDefaultAsync(x => x.ID == ID)
            ?? throw new NotFoundException($"La localizacion {ID} no existe");
        _context.Remove(location);
        await _context.SaveChangesAsync();
    }
}