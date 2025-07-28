using KantarBooks.DataServer.DataAccess;
using KantarBooks.DataServer.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace KantarBooks.DataServer.UnitTest.DataAccess;

/// <summary>
/// Unit Tests for the BookRepository service.
/// </summary>
[TestClass]
public class BookRepositoryUnitTests {

    /// <summary>
    /// Tests whether the GetBooks method returns the three books stored in
    /// the test database.
    /// </summary>
    [TestMethod]
    public void GetBooks_Test() {
        var repository = BuildRepository();
        
        var result = repository.GetBooks();
        Assert.IsNotNull(result);
        Assert.AreEqual(3, result.Count());
    }

    [TestMethod]
    public void AddOrUpdateBook_BookNotFound_Test() {
        var repository = BuildRepository();
        var book = new Book() {
            Id = 4,
            Code = "KBB4",
            Name = "Test Book",
            AuthorCode = "KBP3",
            PublisherCode = "KBP3",
            Borrowed = false
        };
        
        var result = repository.AddOrUpdateBook(book);
        Assert.IsNotNull(result);
        Assert.AreEqual(4, result.Id);

        result = repository.DeleteBook(book.Code);
        Assert.IsNotNull(result );
        Assert.AreEqual(4, result.Id);
    }

    [TestMethod]
    public void AddOrUpdateBook_BookFound_Test() {
        var repository = BuildRepository();
        var book = new Book() {
            Id = 4,
            AuthorCode = "KBB2",
        };
        
        var result = repository.AddOrUpdateBook(book);
        Assert.IsNotNull(result);
        Assert.AreEqual(4, result.Id);

        book.AuthorCode = "KBB3";
        result = repository.AddOrUpdateBook(book);
        Assert.IsNotNull(result);
        Assert.AreEqual("KBB2", result.AuthorCode);
    }
    
    [TestMethod]
    public void BorrowBook_BookNotFound_Test() {}
    
    [TestMethod]
    public void BorrowBook_UserNotFound_Test() {}
    
    [TestMethod]
    public void BorrowBook_BookFoundUserFound_Test() {}
    
    [TestMethod]
    public void Deliver_BookNotFound_Test() {}
    
    [TestMethod]
    public void Deliver_UserNotFound_Test() {}
    
    [TestMethod]
    public void Deliver_BookFoundUserFound_Test() {}
    
    [TestMethod]
    public void DeleteBook_BookNotFound_Test() {
        
    }
    
    [TestMethod]
    public void DeleteBook_BookFound_Test() {
        
    }
    
    /// <summary>
    /// Creates a mock KantarBooksContext using a local sqlite3 database.
    /// </summary>
    /// <returns>The mocked KantarBooksContext.</returns>
    private KantarBooksContext BuildMockContext() {
        var options = new DbContextOptionsBuilder<KantarBooksContext>() 
            .UseSqlite("Data Source=testdb.sqlite;")
            .Options;
        return new KantarBooksContext(options);
    }
    
    /// <summary>
    /// Encapsulates initialization logic for BookRepository objects.
    /// </summary>
    /// <returns>The BookRepository instance.</returns>
    private BookRepository BuildRepository() {
        var context = BuildMockContext();

        var repository = new BookRepository(context);
        repository.LoadCache();
        return repository;
    }
}