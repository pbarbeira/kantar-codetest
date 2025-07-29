using KantarBooks.DataServer.Models;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;

namespace KantarBooks.DataServer.Data;

/// <summary>
/// Handles operations and bookkeeping related to Book objects.
/// </summary>
public class BookRepository(KantarBooksContext context) : IBookRepository, IDisposable, IAsyncDisposable {
    private KantarBooksContext _context => context;
    
    public IEnumerable<Book> GetBooks() {
        return _context.Books.ToList();
    }

    public Book? GetBookById(long id) {
        return _context.Books.FirstOrDefault(b => b.Id == id);
    }

    public Book? AddOrUpdateBook(Book book) {
        var data = _context.Books.Find(book.Id);
        if (data == null) {
            data = _context.Books.Add(book).Entity;
        }
        else {
            _context.Entry(data).CurrentValues.SetValues(book);
        }
        _context.SaveChanges();
        return data;
    }

    public Book? DeleteBook(long id) {
        var book = _context.Books.Find(id);
        if (book == null) {
            return null;
        }
        var result = _context.Remove(book).Entity;
        _context.SaveChanges();
        return result;
    }

    public void Dispose() {
        context.Dispose();
    }

    public async ValueTask DisposeAsync() {
        await context.DisposeAsync();
    }
}