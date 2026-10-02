using AutoMapper;

using Microsoft.EntityFrameworkCore;

using Unova.Domain;

namespace Unova.App.Services;

public class BookService : IBookService
{
    private readonly IMapper _mapper;
    private readonly UnovaDbContext _context;

    public BookService(IMapper mapper, UnovaDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<IEnumerable<BookReadDto>> GetAll()
    {
        var books = await _context.Books
            .AsNoTracking()
            .ToListAsync();
        return _mapper.Map<IEnumerable<BookReadDto>>(books);
    }

    public async Task<BookReadDto> GetByID(int ID)
    {
        var book = await _context.Books
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.ID == ID)
            ?? throw new NotFoundException($"El libro con ID {ID} no existe");
        return _mapper.Map<BookReadDto>(book);
    }

    public async Task<BookDetailDto> GetDetail(int ID)
    {
        var book = await _context.Books
            .Include(x => x.Category)
            .Include(x => x.Author)
            .Include(x => x.Copies)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.ID == ID)
            ?? throw new NotFoundException($"El libro con ID {ID} no existe");
        return _mapper.Map<BookDetailDto>(book);
    }

    public async Task<BookReadDto> Create(BookCreateDto dto)
    {
        var bookExists = await _context.Books.AnyAsync(x => x.ISBN.Equals(dto.ISBN));
        if (bookExists)
            throw new BadRequestException($"El libro con ISBN {dto.ISBN} ya figura en nuestra base de datos");

        var categoryExists = await _context.Categories.AnyAsync(x => x.ID == dto.CategoryID);
        if (!categoryExists)
            throw new NotFoundException($"La categoria con ID {dto.CategoryID} no existe");

        var authorExists = await _context.Authors.AnyAsync(x => x.ID == dto.AuthorID);
        if (!authorExists)
            throw new NotFoundException($"El autor con ID {dto.AuthorID} no existe");

        //Si la fecha es mayor a la fecha actual, lanzamos badrequest
        if (dto.PublicationAt > DateTime.UtcNow)
            throw new BadRequestException($"La fecha de publicacion es invalida. No puede ser mayor a la actual");

        var book = _mapper.Map<Book>(dto);

        _context.Add(book);
        await _context.SaveChangesAsync();
        return _mapper.Map<BookReadDto>(book);
    }

    public async Task Delete(int ID)
    {
        var book = await _context.Books.FirstOrDefaultAsync(x => x.ID == ID)
            ?? throw new NotFoundException($"El libro con ID {ID} no existe");

        var bookHasAnyBooking = await _context.Bookings.AnyAsync(x => x.BookID == ID && x.Status == EBookingStatus.Active);
        if (bookHasAnyBooking)
            throw new BadRequestException($"El Libro no puede ser eliminado. Tiene reservas activas");

        _context.Remove(book);
        await _context.SaveChangesAsync();
    }
}
