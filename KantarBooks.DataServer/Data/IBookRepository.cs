using KantarBooks.DataServer.Models;

namespace KantarBooks.DataServer.Data;

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
    /// Returns the book associated with the given code.
    /// </summary>
    /// <param name="id">The id of the book to be found.</param>
    /// <returns>The book data associated with the given code upon success, null
    /// otherwise.</returns>
    Book? GetBookById(long id);
    
    /// <summary>
    /// Saves a book in the database.
    /// </summary>
    /// <param name="book">The book to be saved in the database.</param>
    /// <returns>The book object returned from the dbContext call.</returns>
    Book? AddOrUpdateBook(Book book);
    
    /// <summary>
    /// Deletes a book from the database.
    /// </summary>
    /// <param name="id">The id of book to be deleted from the database.</param>
    /// <returns>The book object returned from the dbContext call.</returns>
    Book? DeleteBook(long id);
}