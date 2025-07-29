using KantarBooks.DataServer.Models;

namespace KantarBooks.DataServer.Data.Repository;

/// <summary>
/// Interface class for BookRepository
/// </summary>
public interface IBookRepository : IDisposable{
    
    /// <summary>
    /// Returns the list of all books in the database.
    /// </summary>
    /// <returns>List with all books in the database.</returns>
    IEnumerable<Book> GetBooks();
    
    /// <summary>
    /// Saves a book in the database.
    /// </summary>
    /// <param name="book">The book to be saved in the database.</param>
    /// <returns>The book object returned from the dbContext call.</returns>
    Book? AddOrUpdateBook(Book book);
    
    /// <summary>
    /// Marks a book as borrowed in the database..
    /// </summary>
    /// <param name="book">The book to be marked as borrowed in the database.</param>
    /// <returns>The book object returned from the dbContext call.</returns>
    Book? BorrowBook(string bookCode, string userCode);
    
    /// <summary>
    /// Marks a book as returned in the database.
    /// </summary>
    /// <param name="book">The book to be marked as returned in the database.</param>
    /// <returns>The book object returned from the dbContext call.</returns>
    Book? DeliverBook(string bookCode, string userCode);
    
    /// <summary>
    /// Deletes a book from the database.
    /// </summary>
    /// <param name="book">The book to be deleted from the database.</param>
    /// <returns>The book object returned from the dbContext call.</returns>
    Book? DeleteBook(string code);
}