using AtlasLMS.Application.Contracts;
using AtlasLMS.Data;
using AtlasLMS.Domain.Entities;
using AtlasLMS.Domain.Exceptions;
using AtlasLMS.Shared.DTOs.Create;
using AtlasLMS.Shared.DTOs.Detail;
using AtlasLMS.Shared.DTOs.Read;
using AtlasLMS.Shared.DTOs.Update;
using AtlasLMS.Tools;

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

        if (AtlasHelper.IsNotNullableInteger(dto.LocationID))
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

        if (AtlasHelper.IsDateGreater(dto.PublicationAt))
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

        if (AtlasHelper.IsNotNullableInteger(dto.AuthorID))
        {
            var authorExists = await _context.Authors.AnyAsync(x => x.ID == dto.AuthorID);
            if (!authorExists)
                throw new NotFoundException($"El autor con el ID {dto.AuthorID} no existe");
        }

        if (AtlasHelper.IsNotNullableInteger(dto.CategoryID))
        {
            var categoryExists = await _context.Categories.AnyAsync(x => x.ID == dto.CategoryID);
            if (!categoryExists)
                throw new NotFoundException($"La categoria con el ID {dto.CategoryID} no existe");
        }

        if (AtlasHelper.IsNotNullableInteger(dto.LocationID))
        {
            var locationExists = await _context.Locations.AnyAsync(x => x.ID == dto.LocationID);
            if (!locationExists)
                throw new NotFoundException($"La localizacion con el ID {dto.LocationID} no existe");
        }

        if (AtlasHelper.IsNotStringEmpty(dto.ISBN))
        {
            var bookExists = await _context.Books.AnyAsync(x => x.ISBN.Equals(dto.ISBN) && x.ID != ID);
            if (bookExists)
                throw new BadRequestException($"El libro con ISBN {dto.ISBN} ya figura en nuestra base de datos");
        }

        if (AtlasHelper.IsNotNullAndFutureDate(dto.PublicationAt))
            throw new BadRequestException($"La fecha de publicacion es invalida. No puede ser mayor a la actual");

        book.Title = AtlasHelper.GetOrFallbackStr(dto.Title, book.Title);
        book.ISBN = AtlasHelper.GetOrFallbackStr(dto.ISBN, book.ISBN);
        book.Synopsis = AtlasHelper.GetOrFallbackStr(dto.Synopsis, book.Synopsis);
        book.Stock = AtlasHelper.ResolveNullableInt(dto.Stock, book.Stock);
        book.PublicationAt = AtlasHelper.GetOrExistingDate(dto.PublicationAt, book.PublicationAt);
        book.AuthorID = AtlasHelper.GetOrExistingIntNullable(dto.AuthorID, book.AuthorID);
        book.CategoryID = AtlasHelper.GetOrExistingIntNullable(dto.CategoryID, book.CategoryID);
        book.LocationID = AtlasHelper.ResolveNullableInt(dto.LocationID, book.LocationID);

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
