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
    
    /// <summary>
    /// Sets up test context by running a sql script that resets the test database.
    /// </summary>
    [ClassInitialize]
    public static void Setup(TestContext testContext)
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
    
    /// <summary>
    /// Tests whether GetBookById returns null when book is not found.
    /// </summary>
    [TestMethod]
    public void GetBookById_NotFound_Test() {
        var repository = BuildRepository();

        var result = repository.GetBookById(0);
        Assert.IsNull(result);
    }
    
    /// <summary>
    /// Test whether GetbookById returns results when book is found.
    /// </summary>
    [TestMethod]
    public void GetBookById_Found_Test() {
        var repository = BuildRepository();

        var result = repository.GetBookById(1);
        Assert.IsNotNull(result);
    }

    /// <summary>
    /// Tests whther AddOrUpdateBook adds a book to the database when the book does not exist.
    /// </summary>
    [TestMethod]
    public void AddOrUpdateBook_BookNotFound_Test() {
        var repository = BuildRepository();
        var bookCount = repository.GetBooks().Count();
        var book = BuildBook();
        
        var result = repository.AddOrUpdateBook(book);
        Assert.IsNotNull(result);
        Assert.IsTrue(repository.GetBooks().Count() > bookCount);

        result = repository.DeleteBook(result.Id);
        Assert.IsNotNull(result);
        Assert.AreEqual(repository.GetBooks().Count(), bookCount);
    }

    /// <summary>
    /// Tests whther AddOrUpdateBook updates a book in the database when the book exists.
    /// </summary>
    [TestMethod]
    public void AddOrUpdateBook_BookFound_Test() {
        var repository = BuildRepository();
        var book = repository.GetBookById(3);
        var bookCount = repository.GetBooks().Count();
        book.AuthorCode = "KBA2";
        
        var result = repository.AddOrUpdateBook(book);
        Assert.IsNotNull(result);
        Assert.AreEqual(3, result.Id);
        Assert.AreEqual("KBA2", result.AuthorCode);
        Assert.AreEqual(bookCount, repository.GetBooks().Count());
    }
    
  
    /// <summary>
    /// Tests whether DeleteBook returns null when the book exists.
    /// </summary>
    [TestMethod]
    public void DeleteBook_BookNotFound_Test() {
        var repository = BuildRepository();

        var result = repository.DeleteBook(4);
        Assert.IsNull(result);
    }
    
    /// <summary>
    /// Tests whether DeleteBook deletes a book from the database when it exists.
    /// </summary>
    [TestMethod]
    public void DeleteBook_BookFound_Test() {
        var repository = BuildRepository();
        var bookCount = repository.GetBooks().Count();

        var result = repository.DeleteBook(1);
        Assert.IsNotNull(result);
        Assert.AreEqual(bookCount - 1, repository.GetBooks().Count());

        result = repository.AddOrUpdateBook(result);
        Assert.IsNotNull(result);
        Assert.AreEqual(bookCount, repository.GetBooks().Count());
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
    /// Helper method to automate building the repository object.
    /// </summary>
    /// <returns>The built BookRepository instance.</returns>
    private BookRepository BuildRepository() {
        var context = BuildMockContext();

        var repository = new BookRepository(context);
        return repository;
    }
    
    /// <summary>
    /// Helper method to automate building Book objects.
    /// </summary>
    /// <returns>The built Book object</returns>
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