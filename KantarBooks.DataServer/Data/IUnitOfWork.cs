using KantarBooks.DataServer.Data.Repository;
using KantarBooks.DataServer.Model;
using KantarBooks.DataServer.Model.Agent;

namespace KantarBooks.DataServer.Data;

/// <summary>
/// Interface class for UnitOfWork. Contains used repositories as properties
/// to facilitate mocking in unit tests. Acts as a data object containing
/// references to the different repositories, as well as initialization
/// logic to pull data from the database.
/// </summary>
public interface IUnitOfWork : IDisposable{
   
    IUserRepository UserRepository { get; }
    IBookRepository BookRepository { get; }
    IDictionary<string, Author> Authors { get; }
    IDictionary<string, Publisher> Publishers { get; }    

    IEnumerable<Book> GetBooks();
}