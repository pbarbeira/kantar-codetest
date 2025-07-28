using KantarBooks.DataServer.Config;
using KantarBooks.DataServer.Data.Repository;
using KantarBooks.DataServer.Model;
using KantarBooks.DataServer.Model.Agent;

namespace KantarBooks.DataServer.Data;

/// <summary>
/// Implementation of IUnitOfWork.
/// </summary>
public class UnitOfWork : IUnitOfWork{
    
    public IUserRepository UserRepository { get; }
    public IBookRepository BookRepository { get; }
    public IDictionary<string, Author> Authors { get; }
    public IDictionary<string, Publisher> Publishers { get; }    
    
    /// <summary>
    /// Default constructor for UnitOfWork. Used for test purposes.
    /// </summary>
    public UnitOfWork(IUserRepository agentRepository, IBookRepository bookRepository, IConfiguration configuration) {
        UserRepository = agentRepository;
        BookRepository = bookRepository;
        
        var agentConfig = configuration.GetSection("AgentConfig").Get<AgentConfig>() ?? new AgentConfig();
        Authors = agentConfig.Authors.ToDictionary(x => x.Code, x => x);
        Publishers = agentConfig.Publishers.ToDictionary(x => x.Code, x => x);
    }

    public IEnumerable<Book> GetBooks() {
        var books = BookRepository.GetBooks().ToList();
        foreach (var book in books) {
            book.Author = Authors.TryGetValue(book.AuthorCode, out var author) ? author : new Author();
            book.Publisher = Publishers.TryGetValue(book.PublisherCode, out var publisher) ? publisher : new Publisher();
        }
        return books;
    }
    
    
    public void Dispose() {
        UserRepository.Dispose();
        BookRepository.Dispose();
    }
}