using KantarBooks.DataServer.Models;

namespace KantarBooks.DataServer.Data.Repository;

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
        var result = _context.Books.Update(book).Entity;
        _context.SaveChanges();
        return result;
    }

    public Book? DeleteBook(Book book) {
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