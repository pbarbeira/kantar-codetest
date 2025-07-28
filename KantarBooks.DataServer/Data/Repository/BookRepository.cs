using KantarBooks.DataServer.Model;

namespace KantarBooks.DataServer.Data.Repository;

/// <summary>
/// Handles operations and bookkeeping related to Book objects.
/// </summary>
public class BookRepository(KantarBooksContext context) 
    : Repository<Book>(context), IBookRepository {
    
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
}