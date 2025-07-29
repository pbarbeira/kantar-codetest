using KantarBooks.DataServer.Models;

namespace KantarBooks.DataServer.Data;

/// <summary>
/// Interface class for UnitOfWork. Contains used repositories as properties
/// to facilitate mocking in unit tests. Acts as a data object containing
/// references to the different repositories, as well as initialization
/// logic to pull data from the database.
/// </summary>
public interface IUnitOfWork : IDisposable{
    /// <summary>
    /// Repository object handling the Book ORM operations
    /// </summary>
    IBookRepository BookRepository { get; }
    
    /// <summary>
    /// Dictionary containing author information.
    /// </summary>
    IDictionary<string, Author> Authors { get; }
    
    /// <summary>
    /// Dictionary containing publisher information;
    /// </summary>
    IDictionary<string, Publisher> Publishers { get; }    

    /// <summary>
    /// Loads up author and publisher information into book objects. Returns
    /// the resulting objects.
    /// </summary>
    /// <returns>List of fully loaded book objects.</returns>
    IEnumerable<Book> GetBooks();

    /// <summary>
    /// Loads publisher and author data into Book model.
    /// </summary>
    /// <param name="book">The book model to be loaded.</param>
    /// <returns>The loaded Book model</returns>
    Book LoadPublisherAndAuthorData(Book book);
}