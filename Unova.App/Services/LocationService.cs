using AutoMapper;

using Microsoft.EntityFrameworkCore;

using Unova.App.Contracts;
using Unova.Domain.Entities;
using Unova.Infrastructure;
using Unova.Shared.DTOs.Create;
using Unova.Shared.DTOs.Detail;
using Unova.Shared.DTOs.Read;
using Unova.Shared.DTOs.Update;

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
            .Include(x => x.Books)
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
        location.Aisle = dto.Aisle ?? location.Aisle;
        location.Column = dto.Column ?? location.Column;
        location.Shelf = dto.Shelf ?? location.Shelf;

        location.LimitOfBooks = dto.LimitOfBooks ?? location.LimitOfBooks;

        location.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();
        return _mapper.Map<LocationReadDto>(location);
    }

    public async Task Delete(int ID)
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