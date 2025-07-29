using Azure.Core;
using KantarBooks.DataServer.Data;
using KantarBooks.DataServer.Models;
using KantarBooks.DataServer.Service;
using Moq;

namespace KantarBooks.DataServer.UnitTest.Service;

/// <summary>
/// Test class for BookService.
/// </summary>
[TestClass]
public class BookServiceUnitTests {

    /// <summary>
    /// Tests whether GetBooks returns a list of Book objects converted into BookDto objects.
    /// </summary>
    [TestMethod]
    public void GetBooks_Test() {
        var mockUnitOfWork =  new Mock<IUnitOfWork>();
        var bookList = BuildMockList();
        mockUnitOfWork.Setup(x => x.GetBooks()).Returns(bookList);
        
        var bookService = new BookService(mockUnitOfWork.Object);
        
        var result = bookService.GetBooks();
        Assert.IsNotNull(result);
        Assert.AreEqual(bookList.Count, result.Count);
        for (int i = 0; i < result.Count; i++) {
            Assert.AreEqual(bookList[i].Id, result[i].Id);
        }
    }
    
    /// <summary>
    /// Tests whether AddOrUpdate returns a non-null result when the repository does not fault.
    /// </summary>
    [TestMethod]
    public void AddOrUpdateBook_OK_Test() {
        var mockUnitOfWork =  new Mock<IUnitOfWork>();
        var mockBook = BuildMockBook(false);
        mockUnitOfWork.Setup(x => x.BookRepository.AddOrUpdateBook(It.IsAny<Book>()))
            .Returns(mockBook);
        mockUnitOfWork.Setup(x => x.LoadPublisherAndAuthorData(It.IsAny<Book>()))
            .Returns(mockBook);
        
        var bookService = new BookService(mockUnitOfWork.Object);
        
        var result = bookService.AddOrUpdateBook(new BookDto());
        Assert.IsNotNull(result);
        Assert.AreEqual(result.Id, mockBook.Id);
    }

    /// <summary>
    /// Tests whether AddOrUpdateBook throws when the repository faults.
    /// </summary>
    [TestMethod]
    public void AddOrUpdateBook_Throws_Test() {
        var mockUnitOfWork =  new Mock<IUnitOfWork>();
        mockUnitOfWork.Setup(x => x.BookRepository.AddOrUpdateBook(It.IsAny<Book>()))
            .Returns<Book>(null);
        
        var bookService = new BookService(mockUnitOfWork.Object);
        
        Assert.ThrowsException<Exception>(() => bookService.AddOrUpdateBook(new BookDto()));
    }
    
    /// <summary>
    /// Tests whether BorrowBook returns a non-null result and flips the borrowed bit when the repository does not fault.
    /// </summary>
    [TestMethod]
    public void BorrowBook_Ok_Test() {
        var mockUnitOfWork =  new Mock<IUnitOfWork>();
        var mockBook = BuildMockBook(false);
        mockUnitOfWork.Setup(x => x.BookRepository.GetBookById(It.IsAny<long>()))
            .Returns(mockBook);
        mockUnitOfWork.Setup(x => x.LoadPublisherAndAuthorData(It.IsAny<Book>()))
            .Returns(mockBook);
        
        var bookService = new BookService(mockUnitOfWork.Object);
        
        var result = bookService.BorrowBook(0);
        Assert.IsNotNull(result);
        Assert.AreEqual(result.Id, mockBook.Id);
        Assert.IsTrue(result.Borrowed);
    }
    
    /// <summary>
    /// Tests whether BorrowBook throws when the system tries to borrow a book that's already borrowed.
    /// </summary>
    [TestMethod]
    public void BorrowBook_Throws_BorrowedIsTrue_Test() {
        var mockUnitOfWork =  new Mock<IUnitOfWork>();
        var mockBook = BuildMockBook(true);
        mockUnitOfWork.Setup(x => x.BookRepository.GetBookById(It.IsAny<long>()))
            .Returns(mockBook);
        mockUnitOfWork.Setup(x => x.LoadPublisherAndAuthorData(It.IsAny<Book>()))
            .Returns(mockBook);
        
        var bookService = new BookService(mockUnitOfWork.Object);
        
        Assert.ThrowsException<Exception>(() => bookService.BorrowBook(0));
    }
    
    /// <summary>
    /// Tests whether BorrowBook throws when the repository faults.
    /// </summary>
    [TestMethod]
    public void BorrowBook_Throws_BookNotFound_Test() {
        var mockUnitOfWork =  new Mock<IUnitOfWork>();
        mockUnitOfWork.Setup(x => x.BookRepository.GetBookById(It.IsAny<long>()))
            .Returns<Book>(null);
        
        var bookService = new BookService(mockUnitOfWork.Object);
        
        Assert.ThrowsException<Exception>(() => bookService.BorrowBook(0));
    }
    
    /// <summary>
    /// Tests whether DeliverBook and flips the borrowed bit returns a non-null result when the repository does not fault.
    /// </summary>
    [TestMethod]
    public void DeliverBook_Ok_Test() {
        var mockUnitOfWork =  new Mock<IUnitOfWork>();
        var mockBook = BuildMockBook(true);
        mockUnitOfWork.Setup(x => x.BookRepository.GetBookById(It.IsAny<long>()))
            .Returns(mockBook);
        mockUnitOfWork.Setup(x => x.LoadPublisherAndAuthorData(It.IsAny<Book>()))
            .Returns(mockBook);
        
        var bookService = new BookService(mockUnitOfWork.Object);
        
        var result = bookService.DeliverBook(0);
        Assert.IsNotNull(result);
        Assert.AreEqual(result.Id, mockBook.Id);
        Assert.IsFalse(result.Borrowed);
    }
    
    /// <summary>
    /// Tests whether DeliverBook throws when the system tries to deliver a book that's already delivered.
    /// </summary>
    [TestMethod]
    public void DeliverBook_Throws_BorrowedIsFalse_Test() {
        var mockUnitOfWork =  new Mock<IUnitOfWork>();
        var mockBook = BuildMockBook(false);
        mockUnitOfWork.Setup(x => x.BookRepository.GetBookById(It.IsAny<long>()))
            .Returns(mockBook);
        mockUnitOfWork.Setup(x => x.LoadPublisherAndAuthorData(It.IsAny<Book>()))
            .Returns(mockBook);
        
        var bookService = new BookService(mockUnitOfWork.Object);
        
        Assert.ThrowsException<Exception>(() => bookService.DeliverBook(0));
    }
    
    /// <summary>
    /// Tests whether DeliverBook throws when the repository faults.
    /// </summary>
    [TestMethod]
    public void DeliverBook_Throws_NotFound_Test() {
        var mockUnitOfWork =  new Mock<IUnitOfWork>();
        mockUnitOfWork.Setup(x => x.BookRepository.GetBookById(It.IsAny<long>()))
            .Returns<Book>(null);
        
        var bookService = new BookService(mockUnitOfWork.Object);
        
        Assert.ThrowsException<Exception>(() => bookService.DeliverBook(0));
    }
    
    /// <summary>
    /// Tests whether DeleteBook returns a non-null result when the repository does not fault.
    /// </summary>
    [TestMethod]
    public void DeleteBook_Ok_Test() {
        var mockUnitOfWork =  new Mock<IUnitOfWork>();
        var mockBook = BuildMockBook(false);
        mockUnitOfWork.Setup(x => x.BookRepository.DeleteBook(It.IsAny<long>()))
            .Returns(mockBook);
        
        var bookService = new BookService(mockUnitOfWork.Object);
        
        var result = bookService.DeleteBook(0);
        Assert.IsNotNull(result);
        Assert.AreEqual(result.Id, mockBook.Id);
    }
    
    /// <summary>
    /// Tests whether DeleteBook throws when the repository faults.
    /// </summary>
    [TestMethod]
    public void DeleteBook_Throws_Test() {
        var mockUnitOfWork =  new Mock<IUnitOfWork>();
        mockUnitOfWork.Setup(x => x.BookRepository.DeleteBook(It.IsAny<long>()))
            .Returns<Book>(null);
        
        var bookService = new BookService(mockUnitOfWork.Object);
        
        Assert.ThrowsException<Exception>(() => bookService.DeleteBook(0));
    }
    
    /// <summary>
    /// Helper method to automate building mock Book's.
    /// </summary>
    /// <returns>The built Book object.</returns>
    private Book BuildMockBook(bool borrowed) {
        return new Book() {
            Id = 4,
            Title = "Test Book",
            Author = TestUtils.BuildAuthor(),
            Publisher = TestUtils.BuildPublisher(),
            Borrowed = borrowed
        };
    }
    
    /// <summary>
    /// Helper method to automate building the mock Book list.
    /// </summary>
    /// <returns>The built Book list.</returns>
    private IList<Book> BuildMockList() {
        return new List<Book>() {
            BuildMockBook(true),
            BuildMockBook(false)
        };
    }
}
