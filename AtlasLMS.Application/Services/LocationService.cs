using AtlasLMS.Application.Contracts;
using AtlasLMS.Data;
using AtlasLMS.Domain.Entities;
using AtlasLMS.Domain.Exceptions;
using AtlasLMS.Shared.DTOs.Create;
using AtlasLMS.Shared.DTOs.Detail;
using AtlasLMS.Shared.DTOs.Read;
using AtlasLMS.Shared.DTOs.Update;

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

    public async Task<LocationDetailDto> GetLocationDetailAsync(int ID)
    {
        var location = await _context.Locations.FirstOrDefaultAsync(x => x.ID == ID)
            ?? throw new NotFoundException($"La ubicación con ID {ID} no existe");
        return _mapper.Map<LocationDetailDto>(location);
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

    public async Task<LocationReadDto> UpdateLocationAsync(int ID, LocationUpdateDto dto)
    {
        var location = await _context.Locations.FirstOrDefaultAsync(x => x.ID == ID)
            ?? throw new NotFoundException($"Ubicaion con ID {ID} no encontrada");

        //Normalizamos para guardar unicamente en mayusculas
        if (!string.IsNullOrEmpty(dto.Shelf)) dto.Shelf = dto.Shelf.ToUpper();
        if (!string.IsNullOrEmpty(dto.Column)) dto.Column = dto.Column.ToUpper();
        if (!string.IsNullOrEmpty(dto.Aisle)) dto.Aisle = dto.Aisle.ToUpper();

        //Si la localizacion concatenando, pasillo, columna y estante existe, lanzamos badrequest
        var existsLocation = await _context.Locations.AnyAsync(
            x => x.Column.Equals(dto.Column) &&
            x.Shelf.Equals(dto.Shelf) &&
            x.Aisle.Equals(dto.Aisle) &&
            x.ID != ID);
        if (existsLocation)
            throw new BadRequestException($"Ya existe la localizacion introducida");

        //En el caso que no venga la informacion en el DTO guardamos el valor anterior
        location.Aisle = !string.IsNullOrEmpty(dto.Aisle) ? dto.Aisle : location.Aisle;
        location.Column = !string.IsNullOrEmpty(dto.Column) ? dto.Column : location.Column;
        location.Shelf = !string.IsNullOrEmpty(dto.Shelf) ? dto.Shelf : location.Shelf;

        location.LimitOfBooks = dto.LimitOfBooks ?? location.LimitOfBooks;

        location.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();
        return _mapper.Map<LocationReadDto>(location);
    }

    public async Task DeleteLocationAsync(int ID)
    {
        var location = await _context.Locations.FirstOrDefaultAsync(x => x.ID == ID)
            ?? throw new NotFoundException($"La localizacion con ID {ID} no existe");

        var locationHaveAnyBook = await _context.Books.AnyAsync(x => x.LocationID == ID);
        if (locationHaveAnyBook)
            throw new BadRequestException($"La localizacion a eliminar, contiene libros");

        _context.Remove(location);
        await _context.SaveChangesAsync();
    }
}