using KantarBooks.DataServer.Models;

namespace KantarBooks.DataServer.Service;

/// <summary>
/// Interface for the IBookService class.
/// </summary>
public interface IBookService {
    /// <summary>
    /// Returns a list of all books in the system.
    /// </summary>
    /// <returns>A list with all the books in the system.</returns>
    IList<BookDto> GetBooks();
    
    /// <summary>
    /// Saves a book in the system.
    /// </summary>
    /// <param name="bookDto">The book to be saved.</param>
    /// <returns>A BookDto with the result of the service operation.</returns>
    BookDto? AddOrUpdateBook(BookDto bookDto);
    
    /// <summary>
    /// Marks a book as borrowed.
    /// </summary>
    /// <param name="id">The id of the book to be marked as borrowed.</param>
    /// <returns>A BookDto with the result of the service operation.</returns>
    BookDto? BorrowBook(long id);
    
    /// <summary>
    /// Unmarks a book as borrowed.
    /// </summary>
    /// <param name="id">The id of the book to be unmarked as borrowed.</param>
    /// <returns>A BookDto with the result of the service operation.</returns>
    BookDto? DeliverBook(long id);
    
    /// <summary>
    /// Deletes a book from the system.
    /// </summary>
    /// <param name="id">The id of the book to be deleted.</param>
    /// <returns>A BookDto with the result of the service operation.</returns>
    BookDto? DeleteBook(long id);
}