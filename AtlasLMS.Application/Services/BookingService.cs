using AtlasLMS.Application.Contracts;
using AtlasLMS.Data;
using AtlasLMS.Domain.Entities;
using AtlasLMS.Domain.Exceptions;
using AtlasLMS.Shared.DTOs.Create;
using AtlasLMS.Shared.DTOs.Read;
using AtlasLMS.Shared.Enums;

using AutoMapper;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AtlasLMS.Application.Services;

public class BookingService : IBookingService
{
    private readonly AtlasDbContext _context;
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;

    public BookingService(AtlasDbContext context, IMapper mapper, UserManager<User> userManager)
    {
        _context = context;
        _mapper = mapper;
        _userManager = userManager;
    }

    public async Task<IEnumerable<BookingReadDto>> GetBookingsAsync()
    {
        var bookings = await _context.Bookings.ToListAsync();
        return _mapper.Map<IEnumerable<BookingReadDto>>(bookings);
    }

    public async Task<IEnumerable<BookingReadDto>> GetBookingsByUserAsync(string userID)
    {
        var userExists = await _userManager.Users.AnyAsync(x => x.Id.Equals(userID));
        if (!userExists)
            throw new NotFoundException($"El usuario con ID {userID} no existe");

        var bookings = await _context.Bookings.Where(x => x.UserID.Equals(userID)).Include(x => x.Book).ToListAsync();
        return _mapper.Map<IEnumerable<BookingReadDto>>(bookings);
    }

    public async Task<IEnumerable<BookingReadDto>> GetBookingsByStatusAsync(EBookingStatus status)
    {
        var bookings = await _context.Bookings.Where(x => x.Status == status).ToListAsync();
        return _mapper.Map<IEnumerable<BookingReadDto>>(bookings);
    }

    public async Task<BookingReadDto> GetBookingAsync(int ID)
    {
        var booking = await _context.Bookings
            .Include(x => x.Book)
            .Include(x => x.User)
            .FirstOrDefaultAsync(x => x.ID == ID)
            ?? throw new NotFoundException($"La reserva con ID {ID} no existe");
        return _mapper.Map<BookingReadDto>(booking);
    }

    public async Task<BookingReadDto> GetBookingByBookAsync(int bookID)
    {
        var booking = await _context.Bookings.FirstOrDefaultAsync(x => x.BookID == bookID)
            ?? throw new NotFoundException($"La reserva con el libro {bookID} no existe");
        return _mapper.Map<BookingReadDto>(booking);
    }

    public async Task<BookingReadDto> CreateBookingAsync(BookingCreateDto dto)
    {
        var bookExists = await _context.Books.AnyAsync(x => x.ID == dto.BookID);
        if (!bookExists)
            throw new NotFoundException($"El libro con ID {dto.BookID} no existe");

        var userExists = await _userManager.FindByIdAsync(dto.UserID)
            ?? throw new NotFoundException($"Usuario con ID {dto.UserID} no existe");

        if (dto.StartTime >= dto.PickupDeadline)
            throw new BadRequestException($"La fecha de inicio no puede ser mayor a la de recogida");
        if (dto.StartTime < DateTime.UtcNow || dto.PickupDeadline < DateTime.UtcNow)
            throw new BadRequestException($"Las fechas de inicio/final no pueden ser menor a la fecha actual");

        var bookIsReserved = await _context.Bookings
            .AnyAsync(x => x.BookID == dto.BookID && x.PickupDeadline > dto.StartTime);
        if (bookIsReserved)
            throw new BadRequestException($"El libro ya esta reservado por otro usuario en el rango de fecha indicado {dto.StartTime} ");

        var booking = _mapper.Map<Booking>(dto);
        _context.Add(booking);
        await _context.SaveChangesAsync();
        return _mapper.Map<BookingReadDto>(booking);
    }

    public async Task DeleteBookingAsync(int bookingID)
    {
        var booking = await _context.Bookings.FirstOrDefaultAsync(x => x.ID == bookingID)
            ?? throw new NotFoundException($"La reserva con ID {bookingID} no existe");
        _context.Remove(booking);
        await _context.SaveChangesAsync();
    }

}
