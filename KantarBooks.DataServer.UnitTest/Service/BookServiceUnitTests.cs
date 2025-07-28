using KantarBooks.DataServer.DataAccess;
using KantarBooks.DataServer.Service;
using Moq;

namespace KantarBooks.DataServer.UnitTest.Service;

[TestClass]
public class BookServiceUnitTests {
    
    [TestMethod]
    public void GetBooks_NoBooks()
    {
        var unitOfWork = TestUtils.BuildUnitOfWork();
        var bookService = new BookService(unitOfWork); 
        var result = bookService.GetBooks();
        
        Assert.IsNotNull(result);
        Assert.AreEqual(0, result.Count);
    }

    [TestMethod]
    public void GetBooks_SomeBooks() {

    }
    
    [TestMethod]
    public void GetByAuthor_NoBooks()
    {
        
    }
    
    [TestMethod]
    public void GetByAuthor_InvalidAuthor()
    {
        
    }

    [TestMethod]
    public void GetByAuthor_ValidAuthor()
    {
        
    }
    
    [TestMethod]
    public void GetByPublisher_NoBooks()
    {
        
    }

    [TestMethod]
    public void GetByPublisher_InvalidPublisher()
    {
        
    }
    
    [TestMethod]
    public void GetByPublisher_ValidPublisher()
    {
        
    }

    [TestMethod]
    public void GetBook_NoBooks()
    {
        
    }

    [TestMethod]
    public void GetBook_InvalidId()
    {
        
    }

    [TestMethod]
    public void GetBook_ValidId()
    {
        
    }
    
    [TestMethod]
    public void AddOrUpdateBook_AddBook()
    {
        
    }

    [TestMethod]
    public void AddOrUpdateBook_UpdateBookNoBooks()
    {
        
    }
    
    [TestMethod]
    public void AddOrUpdateBook_UpdateBookNotExist()
    {
        
    }
    
    [TestMethod]
    public void AddOrUpdateBook_UpdateBookExists()
    {
        
    }

    [TestMethod]
    public void DeleteBook_NoBooks()
    {
        
    }
    
    [TestMethod]
    public void DeleteBook_InvalidId()
    {
        
    }

    [TestMethod]
    public void DeleteBook_ValidId()
    {
        
    }

    [TestMethod]
    public void BorrowBook_NoBooks()
    {
        
    }
    
    [TestMethod]
    public void BorrowBook_InvalidBook()
    {
        
    }

    [TestMethod]
    public void BorrowBook_ValidBookInvalidAuthor()
    {
        
    }

    [TestMethod]
    public void BorrowBook_ValidBookValidAuthor()
    {
        
    }
    
    [TestMethod]
    public void DeliverBook_NoBooks()
    {
        
    }
    
    [TestMethod]
    public void DeliverBook_InvalidBook()
    {
        
    }

    [TestMethod]
    public void DeliverBook_ValidBookInvalidAuthor()
    {
        
    }

    [TestMethod]
    public void DeliverBook_ValidBookValidAuthor()
    {
        
    }
    
    #region Constants
    public class Constants
    {
        
    }
    #endregion
}
