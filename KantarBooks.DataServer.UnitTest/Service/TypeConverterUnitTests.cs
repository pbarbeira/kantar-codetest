using KantarBooks.DataServer.Models;
using KantarBooks.DataServer.Service;

namespace KantarBooks.DataServer.UnitTest.Service;

/// <summary>
/// Test class for TypeConverter.
/// </summary>
[TestClass]
public class TypeConverterUnitTests {
    
    /// <summary>
    /// Tests whether BookToDto properly converts a Book object to a BookDto object.
    /// </summary>
    [TestMethod]
    public void BookToDto_Test() {
        var author = TestUtils.BuildAuthor();
        var publisher = TestUtils.BuildPublisher();
        var book = BuildBook(author, publisher);

        var result = TypeConverter.BookToDto(book);
        Assert.AreEqual(Constants.BookId, result.Id);
        Assert.AreEqual(Constants.BookTitle, result.Title);
        Assert.AreEqual(author, result.Author);
        Assert.AreEqual(publisher, result.Publisher);
    }
    
    /// <summary>
    /// Tests whether DtoToBook properly converts a BookDto object to a Book object.
    /// </summary>
    [TestMethod]
    public void DtoToBook_Test() {
        var author = TestUtils.BuildAuthor();
        var publisher = TestUtils.BuildPublisher();
        var bookDto = BuildBookDto(author, publisher);

        var result = TypeConverter.DtoToBook(bookDto);
        Assert.AreEqual(Constants.BookDtoId, result.Id);
        Assert.AreEqual(Constants.BookDtoTitle, result.Title);
        Assert.AreEqual(author.Code, result.AuthorCode);
        Assert.AreEqual(publisher.Code, result.PublisherCode);
    }

    /// <summary>
    /// Tests whether BooksToDto properly converts a list of Book objects to
    /// a list of BookDto objects.
    /// </summary>
    [TestMethod]
    public void BooksToDto_Test() {
        var author = TestUtils.BuildAuthor();
        var publisher = TestUtils.BuildPublisher();
        var book = BuildBook(author, publisher);
        var books = BuildBookList(book);
        
        var results = TypeConverter.BooksToDto(books);
        Assert.AreEqual(1, results.Count);

        var result = results.ElementAt(0);
        Assert.AreEqual(Constants.BookId, result.Id);
        Assert.AreEqual(Constants.BookTitle, result.Title);
        Assert.AreEqual(author, result.Author);
        Assert.AreEqual(publisher, result.Publisher);
    }

    /// <summary>
    /// Helper method to automate building the Book object.
    /// </summary>
    /// <returns></returns>
    private Book BuildBook(Author author, Publisher publisher) {
        return new Book {
            Id = Constants.BookId,
            Title = Constants.BookTitle,
            Author = author,
            Publisher = publisher,
        };
    }

    /// <summary>
    /// Helper method to automate building the BookDto object.
    /// </summary>
    /// <returns></returns>
    private BookDto BuildBookDto(Author author, Publisher publisher) {
        return new BookDto {
            Id = Constants.BookDtoId,
            Title = Constants.BookDtoTitle,
            Author = author,
            Publisher = publisher,
        };
    }

    /// <summary>
    /// Helper method to automate building the list of books.
    /// </summary>
    /// <returns></returns>
    private IList<Book> BuildBookList(params Book[] books) {
        return new List<Book>(books);
    }

    /// <summary>
    /// Constants class. Used to facilitate data validation.
    /// </summary>
    private class Constants {
        /// <summary>
        /// The Id of the book.
        /// </summary>
        public static long BookId = 1;
        
        /// <summary>
        /// The Id of the book DTO.
        /// </summary>
        public static long BookDtoId = 2;
        
        /// <summary>
        /// The Title of the book.
        /// </summary>
        public static string BookTitle = "Book";
        
        /// <summary>
        /// The title of the book DTO.
        /// </summary>
        public static string BookDtoTitle = "BookDto";
    }
}