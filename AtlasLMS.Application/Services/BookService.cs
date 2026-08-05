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

public class BookService : IBookService
{
    private readonly IMapper _mapper;
    private readonly AtlasDbContext _context;

    public BookService(IMapper mapper, AtlasDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<IEnumerable<BookReadDto>> GetBooksAsync()
    {
        var books = await _context.Books.ToListAsync();
        return _mapper.Map<IEnumerable<BookReadDto>>(books);
    }

    public async Task<BookReadDto> GetBook(int ID)
    {
        var book = await _context.Books.FirstOrDefaultAsync(x => x.ID == ID)
            ?? throw new NotFoundException($"El libro con ID {ID} no existe");
        return _mapper.Map<BookReadDto>(book);
    }

    public async Task<BookDetailDto> GetBookDetailAsync(int ID)
    {
        var book = await _context.Books.FirstOrDefaultAsync(x => x.ID == ID)
            ?? throw new NotFoundException($"El libro con ID {ID} no existe");
        return _mapper.Map<BookDetailDto>(book);
    }

    public async Task<BookReadDto> CreateBookAsync(BookCreateDto dto)
    {
        var bookExists = await _context.Books.AnyAsync(x => x.ISBN.Equals(dto.ISBN));
        if (bookExists)
            throw new BadRequestException($"El libro con ISBN {dto.ISBN} ya figura en nuestra base de datos");

        //Validamos si la localizacion existe
        //Si existe, validamos que el limite no haya sido alcanzado el total libros permitidos
        if (dto.LocationID.HasValue)
        {
            var location = await _context.Locations.FirstOrDefaultAsync(x => x.ID == dto.LocationID)
                ?? throw new NotFoundException($"La localizacion '{dto.LocationID}' no existe");

            var totalBooksByLocation = await _context.Books.CountAsync(x => x.LocationID == dto.LocationID);
            if (location.LimitOfBooks == totalBooksByLocation)
                throw new BadRequestException($"La localizacion no permite mas libros. Ya excede del limite");
        }

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

    public async Task<BookReadDto> UpdateBookAsync(int ID, BookUpdateDto dto)
    {
        var book = await _context.Books.FirstOrDefaultAsync(x => x.ID == ID)
            ?? throw new NotFoundException($"El libro con ID {ID} no existe");

        //Si el autor no existe, lanzamos badrequest
        if (dto.AuthorID.HasValue)
        {
            var authorExists = await _context.Authors.AnyAsync(x => x.ID == dto.AuthorID);
            if (!authorExists)
                throw new NotFoundException($"El autor con el ID {dto.AuthorID} no existe");
        }

        //Si la categoria no existe, lanzamos badrequest
        if (dto.CategoryID.HasValue)
        {
            var categoryExists = await _context.Categories.AnyAsync(x => x.ID == dto.CategoryID);
            if (!categoryExists)
                throw new NotFoundException($"La categoria con el ID {dto.CategoryID} no existe");
        }

        //Si la localizacion no existe, lanzamos badrequest
        if (dto.LocationID.HasValue)
        {
            var locationExists = await _context.Locations.AnyAsync(x => x.ID == dto.LocationID);
            if (!locationExists)
                throw new NotFoundException($"La localizacion con el ID {dto.LocationID} no existe");
        }

        //Si el ISBN ya es ocupado por otro ejemplar, lanzamos badrequest
        if (!string.IsNullOrEmpty(dto.ISBN))
        {
            var bookExists = await _context.Books.AnyAsync(x => x.ISBN.Equals(dto.ISBN) && x.ID != ID);
            if (bookExists)
                throw new BadRequestException($"El libro con ISBN {dto.ISBN} ya figura en nuestra base de datos");
        }

        //Si la fecha es mayor a la actual, lanzamos badrequest
        if (dto.PublicationAt.HasValue && dto.PublicationAt > DateTime.UtcNow)
            throw new BadRequestException($"La fecha de publicacion es invalida. No puede ser mayor a la actual");

        //Si el DTO no contiene la informacion, guardamos el valor anterior
        book.Title = !string.IsNullOrEmpty(dto.Title) ? dto.Title : book.Title;
        book.ISBN = !string.IsNullOrEmpty(dto.ISBN) ? dto.ISBN : book.ISBN;
        book.Synopsis = !string.IsNullOrEmpty(dto.Synopsis) ? dto.Synopsis : book.Synopsis;

        book.Stock = dto.Stock ?? book.Stock;
        book.PublicationAt = dto.PublicationAt ?? book.PublicationAt;

        book.AuthorID = dto.AuthorID ?? book.AuthorID;
        book.CategoryID = dto.CategoryID ?? book.CategoryID;
        book.LocationID = dto.LocationID ?? book.LocationID;

        book.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();
        return _mapper.Map<BookReadDto>(book);
    }
    public async Task DeleteBookAsync(int ID)
    {
        var book = await _context.Books.FirstOrDefaultAsync(x => x.ID == ID)
            ?? throw new NotFoundException($"El libro con ID {ID} no existe");

        var bookHasAnyLoan = await _context.Loans.AnyAsync(x => x.BookID == ID && x.Status == ELoanStatus.Active);
        if (bookHasAnyLoan)
            throw new BadRequestException($"El libro no puede ser eliminado. Tiene prestamos activos");

        var bookHasAnyBooking = await _context.Bookings.AnyAsync(x => x.BookID == ID && x.Status == EBookingStatus.Active);
        if (bookHasAnyLoan)
            throw new BadRequestException($"El Libro no puede ser eliminado. Tiene reservas activas");

        _context.Remove(book);
        await _context.SaveChangesAsync();
    }
}
