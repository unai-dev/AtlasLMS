using AtlasLMS.Application.Contracts;
using AtlasLMS.Data;
using AtlasLMS.Domain.Entities;
using AtlasLMS.Domain.Exceptions;
using AtlasLMS.Shared.DTOs.Create;
using AtlasLMS.Shared.DTOs.Detail;
using AtlasLMS.Shared.DTOs.Read;
using AtlasLMS.Tools;

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

    public async Task<IEnumerable<BookingReadDto>> GetBookingsByStatusAsync(EBookingStatus? status)
    {
        var query = _context.Bookings.AsQueryable();

        var filteredBookings = query.Where(x => x.Status == status);
        var bookings = await filteredBookings.ToListAsync();

        return _mapper.Map<IEnumerable<BookingReadDto>>(bookings);
    }

    public async Task<BookingReadDto> GetBookingAsync(int ID)
    {
        var booking = await _context.Bookings.FirstOrDefaultAsync(x => x.ID == ID)
            ?? throw new NotFoundException($"La reserva con ID {ID} no existe");
        return _mapper.Map<BookingReadDto>(booking);
    }

    public async Task<BookingReadDto> GetBookingByBookAsync(int bookID)
    {
        var bookExists = await _context.Books.AnyAsync(x => x.ID == bookID);
        if (!bookExists)
            throw new NotFoundException($"El libro con ID {bookID} no existe");

        var booking = await _context.Bookings.FirstOrDefaultAsync(x => x.BookID == bookID)
            ?? throw new NotFoundException($"La reserva con el libro {bookID} no existe");
        return _mapper.Map<BookingReadDto>(booking);
    }
    public async Task<BookingDetailDto> GetBookingDetailAsync(int ID)
    {
        var booking = await _context.Bookings.FirstOrDefaultAsync(x => x.ID == ID)
            ?? throw new NotFoundException($"La reserva con ID {ID} no existe");
        return _mapper.Map<BookingDetailDto>(booking);
    }

    public async Task<BookingReadDto> CreateBookingAsync(BookingCreateDto dto)
    {
        var book = await _context.Books.FirstOrDefaultAsync(x => x.ID == dto.BookID)
            ?? throw new NotFoundException($"El libro con ID {dto.BookID} no existe");

        var userExists = await _userManager.FindByIdAsync(dto.UserID)
            ?? throw new NotFoundException($"Usuario con ID {dto.UserID} no existe");

        var totalBookingsUser = await _context.Bookings.CountAsync(x => x.UserID == dto.UserID && x.Status == EBookingStatus.Active);
        if (totalBookingsUser >= 2)
            throw new BadRequestException($"Lo sentimos. El usuario {dto.UserID} ha superado el limite de reservas activas");

        if (AtlasHelper.IsAnyDatePast(dto.StartTime))
            throw new BadRequestException($"La fecha de inicio no puede ser menor a la fecha actual");

        var activeBookings = await _context.Bookings
            .CountAsync(x => x.BookID == dto.BookID && x.PickupDeadline > dto.StartTime);
        var activeLoans = await _context.Loans
            .CountAsync(x => x.BookID == dto.BookID && x.DueDate > dto.StartTime);
        if ((activeBookings + activeLoans) >= book.Stock)
            throw new BadRequestException($"No hay ejemplares suficientes para el libro {dto.BookID}");

        var booking = _mapper.Map<Booking>(dto);
        booking.PickupDeadline = booking.StartTime.AddDays(3);

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
