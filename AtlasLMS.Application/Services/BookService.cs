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

        if (dto.LocationID.HasValue)
        {
            var location = await _context.Locations.FirstOrDefaultAsync(x => x.ID == dto.LocationID)
                ?? throw new NotFoundException($"La localizacion '{dto.LocationID}' no existe");
            var totalBooksByLocation = await _context.Books.Where(x => x.LocationID == dto.LocationID).ToListAsync();
            if (location.LimitOfBooks == totalBooksByLocation.Count)
                throw new BadRequestException($"La localizacion no permite mas libros. Ya excede del limite");
        }

        var categoryExists = await _context.Categories.AnyAsync(x => x.ID == dto.CategoryID);
        if (!categoryExists)
            throw new NotFoundException($"La categoria con ID {dto.CategoryID} no existe");

        var authorExists = await _context.Authors.AnyAsync(x => x.ID == dto.AuthorID);
        if (!authorExists)
            throw new NotFoundException($"El autor con ID {dto.AuthorID} no existe");

        if (dto.PublicationAt > DateTime.UtcNow)
            throw new BadRequestException($"La fecha de publicacion es invalida. No puede ser igual a la actual");

        var book = _mapper.Map<Book>(dto);
        _context.Add(book);
        await _context.SaveChangesAsync();
        return _mapper.Map<BookReadDto>(book);
    }

    public async Task<BookReadDto> UpdateBookAsync(int ID, BookUpdateDto dto)
    {
        var book = await _context.Books.FirstOrDefaultAsync(x => x.ID == ID)
            ?? throw new NotFoundException($"El libro con ID {ID} no existe");

        if (dto.AuthorID.HasValue)
        {
            var authorExists = await _context.Authors.AnyAsync(x => x.ID == dto.AuthorID);
            if (!authorExists)
                throw new NotFoundException($"El autor con el ID {dto.AuthorID} no existe");
        }

        if (dto.CategoryID.HasValue)
        {
            var categoryExists = await _context.Categories.AnyAsync(x => x.ID == dto.CategoryID);
            if (!categoryExists)
                throw new NotFoundException($"La categoria con el ID {dto.CategoryID} no existe");
        }

        if (dto.LocationID.HasValue)
        {
            var locationExists = await _context.Locations.AnyAsync(x => x.ID == dto.LocationID.Value);
            if (!locationExists)
                throw new NotFoundException($"La localizacion con el ID {dto.LocationID.Value} no existe");
        }

        if (!string.IsNullOrEmpty(dto.ISBN))
        {
            var bookExists = await _context.Books.AnyAsync(x => x.ISBN.Equals(dto.ISBN));
            if (bookExists)
                throw new BadRequestException($"El libro con ISBN {dto.ISBN} ya figura en nuestra base de datos");
        }

        if (dto.PublicationAt.HasValue && dto.PublicationAt > DateTime.UtcNow)
            throw new BadRequestException($"La fecha de publicacion es invalida. No puede ser igual a la actual");

        book.Title = !string.IsNullOrEmpty(dto.Title) ? dto.Title : book.Title;
        book.ISBN = !string.IsNullOrEmpty(dto.ISBN) ? dto.ISBN : book.ISBN;
        book.Synopsis = !string.IsNullOrEmpty(dto.Synopsis) ? dto.Synopsis : book.Synopsis;

        book.Stock = dto.Stock.HasValue ? dto.Stock.Value : book.Stock;
        book.PublicationAt = dto.PublicationAt.HasValue ? dto.PublicationAt.Value : book.PublicationAt;

        book.AuthorID = dto.AuthorID.HasValue ? dto.AuthorID.Value : book.AuthorID;
        book.CategoryID = dto.CategoryID.HasValue ? dto.CategoryID.Value : book.CategoryID;
        book.LocationID = dto.LocationID.HasValue ? dto.LocationID.Value : book.LocationID;

        book.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();
        return _mapper.Map<BookReadDto>(book);
    }
    public async Task DeleteBookAsync(int ID)
    {
        var book = await _context.Books.FirstOrDefaultAsync(x => x.ID == ID)
            ?? throw new NotFoundException($"El libro con ID {ID} no existe");
        _context.Remove(book);
        await _context.SaveChangesAsync();
    }
}
