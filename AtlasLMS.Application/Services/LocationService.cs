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

    public async Task<IEnumerable<LocationReadDto>> GetLocationsAsync()
    {
        var locations = await _context.Locations.ToListAsync();
        return _mapper.Map<IEnumerable<LocationReadDto>>(locations);
    }

    public async Task<LocationReadDto> GetLocationAsync(int ID)
    {
        var location = await _context.Locations.FirstOrDefaultAsync(x => x.ID == ID)
            ?? throw new NotFoundException($"La localizacion con ID {ID} no existe");
        return _mapper.Map<LocationReadDto>(location);
    }

    public async Task<IEnumerable<string>> GetAislesAsync()
    {
        var aisles = await _context.Locations
            .Select(x => x.Aisle)
            .Distinct()
            .ToListAsync();
        return aisles;
    }

    public async Task<IEnumerable<string>> GetColumnsByAisleAsync(string aisle)
    {
        aisle = aisle.Trim().ToUpper();
        var columns = await _context.Locations
            .Where(x => x.Aisle.ToUpper().Equals(aisle))
            .Select(x => x.Column)
            .Distinct() //Omitimos duplicados
            .ToListAsync();
        return columns;
    }

    public async Task<IEnumerable<string>> GetShelvesAsync(string aisle, string column)
    {
        aisle = aisle.Trim().ToUpper();
        column = column.Trim().ToUpper();
        var shelves = await _context.Locations
            .Where(x => x.Aisle.ToUpper().Equals(aisle) && x.Column.ToUpper().Equals(column))
            .Select(x => x.Shelf)
            .Distinct() //Omitimos duplicados
            .ToListAsync();
        return shelves;
    }

    public async Task<LocationReadDto> CreateLocationAsync(LocationCreateDto dto)
    {
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

    public async Task DeleteLocationAsync(int ID)
    {
        var location = await _context.Locations.FirstOrDefaultAsync(x => x.ID == ID)
            ?? throw new NotFoundException($"La localizacion con ID {ID} no existe");
        _context.Remove(location);
        await _context.SaveChangesAsync();
    }
}