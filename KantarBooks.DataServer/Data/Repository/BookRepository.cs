using KantarBooks.DataServer.Models;
using Microsoft.EntityFrameworkCore;

namespace KantarBooks.DataServer.Data.Repository;

/// <summary>
/// Handles operations and bookkeeping related to Book objects.
/// </summary>
public class BookRepository(KantarBooksContext context) : IBookRepository, IDisposable, IAsyncDisposable {
    private KantarBooksContext _context => context;
    
    public IEnumerable<Book> GetBooks() {
        return _context.Books.ToList();
    }

    public Book? GetBookByCode(string bookCode) {
        return _context.Books.FirstOrDefault(b => b.Code == bookCode);
    }

    public Book? AddOrUpdateBook(Book book) {
        return _context.Books.Update(book).Entity;
    }

    public Book? DeleteBook(Book book) {
        return _context.Remove(book).Entity;
    }

    public void Dispose() {
        context.Dispose();
    }

    public async ValueTask DisposeAsync() {
        await context.DisposeAsync();
    }
}