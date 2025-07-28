using KantarBooks.DataServer.Model;

namespace KantarBooks.DataServer.Data.Repository;

/// <summary>
/// Interface class for BookRepository
/// </summary>
public interface IBookRepository : IDisposable{
    
    IEnumerable<Book> GetBooks();
    Book? AddOrUpdateBook(Book book);
    Book? BorrowBook(string bookCode, string userCode);
    Book? DeliverBook(string bookCode, string userCode);
    Book? DeleteBook(string code);
}