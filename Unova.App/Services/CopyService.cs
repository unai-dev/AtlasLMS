using AutoMapper;

using Microsoft.EntityFrameworkCore;

namespace Unova.App.Services;

public class CopyService : ICopyService
{
    #region Fields
    private readonly IMapper _mapper;
    private readonly UnovaDbContext _context;
    #endregion

    #region Constructor
    public CopyService(IMapper mapper, UnovaDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }
    #endregion

    #region Methods
    public async Task<IEnumerable<CopyReadDto>> GetAll()
    {
        var copies = await _context.Copies
            .AsNoTracking()
            .ToListAsync();
        return _mapper.Map<IEnumerable<CopyReadDto>>(copies);
    }

    public async Task<CopyReadDto> GetByID(int ID)
    {
        var copy = await _context.Copies
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.ID == ID)
            ?? throw new NotFoundException($"El ejemplar con ID {ID} no existe");
        return _mapper.Map<CopyReadDto>(copy);
    }

    public async Task<CopyDetailDto> GetDetail(int ID)
    {
        var copy = await _context.Copies
            .Include(x => x.Book)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.ID == ID)
            ?? throw new NotFoundException($"El ejemplar con ID {ID} no existe");
        return _mapper.Map<CopyDetailDto>(copy);
    }

    public async Task<CopyReadDto> Create(CopyCreateDto dto)
    {
        // Validar que el libro existe
        var bookExists = await _context.Books.AnyAsync(x => x.ID == dto.BookID);
        if (!bookExists)
            throw new NotFoundException($"El libro con ID {dto.BookID} no existe");

        // Validar que no existe un ejemplar duplicado con el mismo código para el mismo libro
        var copyExists = await _context.Copies
            .AnyAsync(x => x.BookID == dto.BookID && x.Code.Equals(dto.Code));
        if (copyExists)
            throw new BadRequestException($"Ya existe un ejemplar con el código '{dto.Code}' para el libro con ID {dto.BookID}");

        var copy = _mapper.Map<Copy>(dto);

        _context.Add(copy);
        await _context.SaveChangesAsync();
        return _mapper.Map<CopyReadDto>(copy);
    }

    public async Task Delete(int ID)
    {
        var copy = await _context.Copies.FirstOrDefaultAsync(x => x.ID == ID)
            ?? throw new NotFoundException($"El ejemplar con ID {ID} no existe");

        _context.Remove(copy);
        await _context.SaveChangesAsync();
    }
    #endregion
}
