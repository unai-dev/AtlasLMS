using AutoMapper;

using Microsoft.EntityFrameworkCore;

namespace Unova.App.Services;

public class LanguageService : ILanguageService
{
    private readonly IMapper _mapper;
    private readonly UnovaDbContext _context;

    public LanguageService(IMapper mapper, UnovaDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<IEnumerable<LanguageReadDto>> GetAll()
    {
        var languages = await _context.Languages
            .AsNoTracking()
            .ToListAsync();
        return _mapper.Map<IEnumerable<LanguageReadDto>>(languages);
    }

    public async Task<LanguageReadDto> GetByID(int ID)
    {
        var language = await _context.Languages
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.ID == ID)
            ?? throw new NotFoundException($"El idioma con ID {ID} no existe");
        return _mapper.Map<LanguageReadDto>(language);
    }

    public async Task<LanguageDetailDto> GetDetail(int ID)
    {
        var language = await _context.Languages
            .Include(x => x.Users)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.ID == ID)
            ?? throw new NotFoundException($"El idioma con ID {ID} no existe");
        return _mapper.Map<LanguageDetailDto>(language);
    }

    public async Task<LanguageReadDto> Create(LanguageCreateDto dto)
    {
        //Normalizamos para guardar unicamente en mayusculas
        dto.Iso639Code = dto.Iso639Code.ToUpper();

        //Si el codigo ISO o el nombre ya existen, lanzamos badrequest
        var existsLanguage = await _context.Languages
            .AnyAsync(x => x.Iso639Code.Equals(dto.Iso639Code) || x.Name.Equals(dto.Name));
        if (existsLanguage)
            throw new BadRequestException($"Ya existe un idioma con el codigo o nombre introducido");

        var language = _mapper.Map<Language>(dto);
        _context.Add(language);
        await _context.SaveChangesAsync();
        return _mapper.Map<LanguageReadDto>(language);
    }

    public async Task Delete(int ID)
    {
        var language = await _context.Languages.FirstOrDefaultAsync(x => x.ID == ID)
            ?? throw new NotFoundException($"El idioma con ID {ID} no existe");

        _context.Remove(language);
        await _context.SaveChangesAsync();
    }
}
