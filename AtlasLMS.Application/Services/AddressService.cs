using AtlasLMS.Application.Contracts;
using AtlasLMS.Data;
using AtlasLMS.Domain.Entities;
using AtlasLMS.Domain.Exceptions;
using AtlasLMS.Shared.DTOs.Create;
using AtlasLMS.Shared.DTOs.Detail;
using AtlasLMS.Shared.DTOs.Read;

using AutoMapper;

using Microsoft.EntityFrameworkCore;

namespace AtlasLMS.Application.Services;

public class AddressService : IAddressService
{
    private readonly AtlasDbContext _context;
    private readonly IMapper _mapper;

    public AddressService(AtlasDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<AddressReadDto>> GetAddressesAsync()
    {
        var addresses = await _context.Addresses
            .AsNoTracking()
            .ToListAsync();
        return _mapper.Map<IEnumerable<AddressReadDto>>(addresses);
    }

    public async Task<AddressReadDto> GetAddressAsync(int ID)
    {
        var address = await _context.Addresses
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.ID == ID)
            ?? throw new NotFoundException($"Address with ID {ID} not found");

        return _mapper.Map<AddressReadDto>(address);
    }

    public async Task<AddressDetailDto> GetAddressDetailAsync(int ID)
    {
        var address = await _context.Addresses
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.ID == ID)
            ?? throw new NotFoundException($"Address with ID {ID} not found");

        return _mapper.Map<AddressDetailDto>(address);
    }

    public async Task<AddressReadDto> CreateAddressAsync(AddressCreateDto dto)
    {
        var addressExists = await _context.Addresses
            .AnyAsync(x => x.MainAddress.Equals(dto.MainAddress));

        if (addressExists)
            throw new BadRequestException($"Main Address {dto.MainAddress} already exists in DB");

        var address = _mapper.Map<Address>(dto);

        _context.Addresses.Add(address);
        await _context.SaveChangesAsync();

        return _mapper.Map<AddressReadDto>(address);
    }

    /**
     * TODO: Update Implementation
     */

    public async Task DeleteAddressAsync(int ID)
    {
        var address = await _context.Addresses
            .FirstOrDefaultAsync(x => x.ID == ID)
            ?? throw new NotFoundException($"Address with ID {ID} not found");

        _context.Addresses.Remove(address);
        await _context.SaveChangesAsync();
    }
}
