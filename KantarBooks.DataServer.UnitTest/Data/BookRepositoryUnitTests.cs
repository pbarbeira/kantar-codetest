using KantarBooks.DataServer.Data;
using KantarBooks.DataServer.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace KantarBooks.DataServer.UnitTest.Data;
/// <summary>
/// Unit Tests for the BookRepository service.
/// </summary>
[TestClass]
public class BookRepositoryUnitTests {
    
    [TestInitialize]
    public void Init()
    {
        var basePath = AppDomain.CurrentDomain.BaseDirectory;
        var connString = $"Data Source={Path.Combine(basePath, "testdb.sqlite")};";
        var sqlScript = File.ReadAllText("Scripts/init.sql");

        using var connection = new SqliteConnection(connString);
        connection.Open();

        using var command = new SqliteCommand(sqlScript, connection);
        command.ExecuteNonQuery();
        
        connection.Close();
    }

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
    public void GetBookById_NotFound_Test() {
        var repository = BuildRepository();

        var result = repository.GetBookById(0);
        Assert.IsNull(result);
    }
    
    [TestMethod]
    public void GetBookById_Found_Test() {
        var repository = BuildRepository();

        var result = repository.GetBookById(1);
        Assert.IsNotNull(result);
    }

    [TestMethod]
    public void AddOrUpdateBook_BookNotFound_Test() {
        var repository = BuildRepository();
        var book = BuildBook();
        
        var result = repository.AddOrUpdateBook(book);
        Assert.IsNotNull(result);
    }

    [TestMethod]
    public void AddOrUpdateBook_BookFound_Test() {
        var repository = BuildRepository();
        var book = repository.GetBookById(3);
        book.AuthorCode = "KBA2";
        
        var result = repository.AddOrUpdateBook(book);
        Assert.IsNotNull(result);
        Assert.AreEqual(3, result.Id);
        Assert.AreEqual("KBA2", result.AuthorCode);
    }
    
  
    [TestMethod]
    public void DeleteBook_BookNotFound_Test() {
        var repository = BuildRepository();

        var result = repository.DeleteBook(4);
        Assert.IsNull(result);
    }
    
    [TestMethod]
    public void DeleteBook_BookFound_Test() {
        var repository = BuildRepository();

        var result = repository.DeleteBook(1);
        Assert.IsNotNull(result);
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
        return repository;
    }

    private Book BuildBook() {
        return new Book() {
            Id = 4,
            Title = "Test Book",
            AuthorCode = "KBP3",
            PublisherCode = "KBP3",
            Borrowed = false
        };
    }
}