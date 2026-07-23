using AtlasLMS.Application.Contracts;
using AtlasLMS.Data;
using AtlasLMS.Domain.Entities;
using AtlasLMS.Domain.Exceptions;
using AtlasLMS.Shared.DTOs.Create;
using AtlasLMS.Shared.DTOs.Read;
using AtlasLMS.Shared.DTOs.Update;
using AtlasLMS.Tools;

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
        var columns = await _context.Locations
            .Where(x => x.Aisle.Equals(aisle))
            .Select(x => x.Column)
            .Distinct() //Omitimos duplicados
            .ToListAsync();
        return columns;
    }

    public async Task<IEnumerable<string>> GetShelvesAsync(string aisle, string column)
    {
        var shelves = await _context.Locations
            .Where(x => x.Aisle.Equals(aisle) && x.Column.Equals(column))
            .Select(x => x.Shelf)
            .Distinct() //Omitimos duplicados
            .ToListAsync();
        return shelves;
    }

    public async Task<LocationReadDto> CreateLocationAsync(LocationCreateDto dto)
    {
        dto.Shelf = AtlasHelper.NormalizeUpper(dto.Shelf.ToUpper());
        dto.Column = AtlasHelper.NormalizeUpper(dto.Column.ToUpper());
        dto.Aisle = AtlasHelper.NormalizeUpper(dto.Aisle.ToUpper());

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

    public async Task<LocationReadDto> UpdateLocationAsync(int ID, LocationUpdateDto dto)
    {
        var location = await _context.Locations.FirstOrDefaultAsync(x => x.ID == ID)
            ?? throw new NotFoundException($"Ubicaion con ID {ID} no encontrada");

        if (AtlasHelper.IsNotStringEmpty(dto.Shelf)) dto.Shelf = AtlasHelper.NormalizeUpper(dto.Shelf);
        if (AtlasHelper.IsNotStringEmpty(dto.Column)) dto.Column = AtlasHelper.NormalizeUpper(dto.Column);
        if (AtlasHelper.IsNotStringEmpty(dto.Aisle)) dto.Aisle = AtlasHelper.NormalizeUpper(dto.Aisle);

        var existsLocation = await _context.Locations.AnyAsync(
            x => x.Column.Equals(dto.Column) &&
            x.Shelf.Equals(dto.Shelf) &&
            x.Aisle.Equals(dto.Aisle) &&
            x.ID != ID);
        if (existsLocation)
            throw new BadRequestException($"Ya existe la localizacion introducida");

        location.Aisle = AtlasHelper.GetOrFallbackAndNormalizeStr(dto.Aisle, location.Aisle);
        location.Column = AtlasHelper.GetOrFallbackAndNormalizeStr(dto.Column, location.Column);
        location.Shelf = AtlasHelper.GetOrFallbackAndNormalizeStr(dto.Shelf, location.Shelf);

        location.LimitOfBooks = AtlasHelper.GetOrExistingIntNullable(dto.LimitOfBooks, location.LimitOfBooks);

        location.UpdatedAt = DateTime.UtcNow;

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