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
    /// <param name="book">The book to be saved.</param>
    /// <returns>A BookDto with the result of the service operation.</returns>
    BookDto AddOrUpdateBook(BookDto book);
    
    /// <summary>
    /// Marks a book as borrowed.
    /// </summary>
    /// <param name="book">The book to be marked as borrowed.</param>
    /// <returns>A BookDto with the result of the service operation.</returns>
    BookDto BorrowBook(BookDto book, string userCode);
    
    /// <summary>
    /// Unmarks a book as borrowed.
    /// </summary>
    /// <param name="book">The book to be unmarked as borrowed.</param>
    /// <returns>A BookDto with the result of the service operation.</returns>
    BookDto DeliverBook(BookDto book, string userCode);
    
    /// <summary>
    /// Deletes a book from the system.
    /// </summary>
    /// <param name="book">The book to be deleted.</param>
    /// <returns>A BookDto with the result of the service operation.</returns>
    BookDto DeleteBook(BookDto book);
}