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
    
    public Book? AddOrUpdateBook(Book book) {
        throw new NotImplementedException();
    }

    public Book? BorrowBook(string bookCode, string userCode) {
        throw new NotImplementedException();
    }
    public Book? DeliverBook(string bookCode, string userCode) {
        throw new NotImplementedException();
    }

    public Book? DeleteBook(string code) {
        throw new NotImplementedException();
    }

    public void Dispose() {
        context.Dispose();
    }

    public async ValueTask DisposeAsync() {
        await context.DisposeAsync();
    }
}