using KantarBooks.DataServer.Config;
using KantarBooks.DataServer.Data.Repository;
using KantarBooks.DataServer.Models;

namespace KantarBooks.DataServer.Data;

/// <summary>
/// Implementation of IUnitOfWork.
/// </summary>
public class UnitOfWork : IUnitOfWork{
    
    public IBookRepository BookRepository { get; }
    public IDictionary<string, Author> Authors { get; }
    public IDictionary<string, Publisher> Publishers { get; }    
    
    /// <summary>
    /// Default constructor for UnitOfWork. Loads author and publisher data
    /// from the AgentConfig object into a dictionary.
    /// </summary>
    public UnitOfWork(IBookRepository bookRepository, IConfiguration configuration) {
        BookRepository = bookRepository;
        
        var agentConfig = configuration.GetSection("AgentConfig").Get<AgentConfig>() ?? new AgentConfig();
        Authors = agentConfig.Authors.ToDictionary(x => x.Code, x => x);
        Publishers = agentConfig.Publishers.ToDictionary(x => x.Code, x => x);
    }

    public IEnumerable<Book> GetBooks() {
        var books = BookRepository.GetBooks().ToList();
        foreach (var book in books) {
            LoadPublisherAndAuthorData(book);
        }
        return books;
    }

    public Book LoadPublisherAndAuthorData(Book book) {
        book.Author = Authors.TryGetValue(book.AuthorCode, out var author) ? author : new Author();
        book.Publisher = Publishers.TryGetValue(book.PublisherCode, out var publisher) ? publisher : new Publisher();
        return book;
    }
    
    
    public void Dispose() {
        BookRepository.Dispose();
    }
}