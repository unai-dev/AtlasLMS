using AutoMapper;

using Microsoft.EntityFrameworkCore;
using Unova.Shared.DTOs.Update;

namespace Unova.App.Services;

public class EnterpriseService : IEnterpriseService
{
    #region Fields
    private readonly IMapper _mapper;
    private readonly UnovaDbContext _context;
    #endregion

    #region Constructor
    public EnterpriseService(IMapper mapper, UnovaDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }
    #endregion

    #region Methods
    public async Task<IEnumerable<EnterpriseReadDto>> GetAll()
    {
        var enterprises = await _context.Enterprises
            .AsNoTracking()
            .ToListAsync();
        return _mapper.Map<IEnumerable<EnterpriseReadDto>>(enterprises);
    }

    public async Task<EnterpriseReadDto> GetByID(int ID)
    {
        var enterprise = await _context.Enterprises
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.ID == ID)
            ?? throw new NotFoundException($"La empresa con ID {ID} no existe");
        return _mapper.Map<EnterpriseReadDto>(enterprise);
    }

    public async Task<EnterpriseDetailDto> GetDetail(int ID)
    {
        var enterprise = await _context.Enterprises
            .Include(x => x.Address)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.ID == ID)
            ?? throw new NotFoundException($"La empresa con ID {ID} no existe");
        return _mapper.Map<EnterpriseDetailDto>(enterprise);
    }

    public async Task<EnterpriseReadDto> Create(EnterpriseCreateDto dto)
    {
        //Validamos si el NIF ya figura en la base de datos
        var enterpriseExists = await _context.Enterprises.AnyAsync(x => x.NIF.Equals(dto.NIF));
        if (enterpriseExists)
            throw new BadRequestException($"La empresa con NIF {dto.NIF} ya figura en nuestra base de datos");

        //Validamos si la direccion existe
        var addressExists = await _context.Addresses.AnyAsync(x => x.ID == dto.AddressID);
        if (!addressExists)
            throw new NotFoundException($"La direccion con ID {dto.AddressID} no existe");

        var enterprise = _mapper.Map<Enterprise>(dto);

        _context.Add(enterprise);
        await _context.SaveChangesAsync();
        return _mapper.Map<EnterpriseReadDto>(enterprise);
    }

    public async Task<EnterpriseReadDto> UpdateEnterpriseAsync(int ID, EnterpriseUpdateDto dto)
    {
        var enterprise = await _context.Enterprises.FirstOrDefaultAsync(x => x.ID == ID)
            ?? throw new NotFoundException($"La empresa con ID {ID} no existe");

        //Si la direccion no existe, lanzamos notfound
        if (dto.AddressID.HasValue)
        {
            var addressExists = await _context.Addresses.AnyAsync(x => x.ID == dto.AddressID);
            if (!addressExists)
                throw new NotFoundException($"La direccion con ID {dto.AddressID} no existe");
        }

        //Si el NIF ya es ocupado por otra empresa, lanzamos badrequest
        if (!string.IsNullOrEmpty(dto.NIF))
        {
            var enterpriseExists = await _context.Enterprises.AnyAsync(x => x.NIF.Equals(dto.NIF) && x.ID != ID);
            if (enterpriseExists)
                throw new BadRequestException($"La empresa con NIF {dto.NIF} ya figura en nuestra base de datos");
        }

        //Si el DTO no contiene la informacion, guardamos el valor anterior
        enterprise.Name = dto.Name ?? enterprise.Name;
        enterprise.Description = dto.Description ?? enterprise.Description;
        enterprise.NIF = dto.NIF ?? enterprise.NIF;

        enterprise.AddressID = dto.AddressID ?? enterprise.AddressID;

        enterprise.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();
        return _mapper.Map<EnterpriseReadDto>(enterprise);
    }

    public async Task Delete(int ID)
    {
        var enterprise = await _context.Enterprises.FirstOrDefaultAsync(x => x.ID == ID)
            ?? throw new NotFoundException($"La empresa con ID {ID} no existe");

        _context.Remove(enterprise);
        await _context.SaveChangesAsync();
    }
    #endregion
}
