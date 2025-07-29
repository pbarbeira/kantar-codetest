using KantarBooks.DataServer.Controllers;
using KantarBooks.DataServer.Models;
using KantarBooks.DataServer.Service;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace KantarBooks.DataServer.UnitTest.Controller;

/// <summary>
/// Test class for BookController.
/// </summary>
[TestClass]
public class BookControllerUnitTests {
    /// <summary>
    /// Tests whether GetAll API returns 200 when service executes smoothly.
    /// </summary>
    [TestMethod]
    public void GetAll_Test() {
        var mockList = BuildMockDtoList();
        var mockService = new Mock<IBookService>();
        
        mockService.Setup(x => x.GetBooks()).Returns(mockList);
        var controller = new BookController(mockService.Object);
        
        var okResult = controller.GetAll() as OkObjectResult;
        Assert.IsNotNull(okResult);

        var result = okResult.Value as IList<BookDto>;
        Assert.IsNotNull(result);
        Assert.AreEqual(2, result.Count);
    }

    /// <summary>
    /// Tests whether AddOrUpdateBook API returns 200 when service executes smoothly.
    /// </summary>
    [TestMethod]
    public void AddOrUpdateBook_Ok_Test() {
        var mockBook = BuildMockDto(false);
        var mockService = new Mock<IBookService>();
        
        mockService.Setup(x => x.AddOrUpdateBook(It.IsAny<BookDto>()))
            .Returns(mockBook);
        var controller = new BookController(mockService.Object);
        
        var okResult = controller.AddOrUpdateBook(mockBook) as OkObjectResult;
        Assert.IsNotNull(okResult);

        var result = okResult.Value as BookDto;
        Assert.IsNotNull(result);
        Assert.AreEqual(mockBook.Id, result.Id);
    }
    
    /// <summary>
    /// Tests whether AddOrUpdateBook API returns 500 when an internal exception is thrown.
    /// </summary>
    [TestMethod]
    public void AddOrUpdateBook_Problem_Test() {
        var mockBook = BuildMockDto(false);
        var mockService = new Mock<IBookService>();
        
        mockService.Setup(x => x.AddOrUpdateBook(It.IsAny<BookDto>()))
            .Throws(new Exception());
        var controller = new BookController(mockService.Object);
        
        var problemResult = controller.AddOrUpdateBook(mockBook) as ObjectResult;
        Assert.IsNotNull(problemResult);
        Assert.IsNotNull(problemResult.Value);
        Assert.AreEqual(500, problemResult.StatusCode);
    }
    
    /// <summary>
    /// Tests whether BorrowBook API returns 200 when service executes smoothly.
    /// </summary>
    [TestMethod]
    public void BorrowBook_Ok_Test() {
        var mockBook = BuildMockDto(false);
        var mockService = new Mock<IBookService>();
        
        mockService.Setup(x => x.BorrowBook(It.IsAny<long>()))
            .Returns(mockBook);
        var controller = new BookController(mockService.Object);
        
        var okResult = controller.BorrowBook(mockBook.Id) as OkObjectResult;
        Assert.IsNotNull(okResult);

        var result = okResult.Value as BookDto;
        Assert.IsNotNull(result);
        Assert.AreEqual(mockBook.Id, result.Id);
    }
    
    /// <summary>
    /// Tests whether BorrowBook API returns 500 when an internal exception is thrown.
    /// </summary>
    [TestMethod]
    public void BorrowBook_Problem_Test() {
        var mockBook = BuildMockDto(false);
        var mockService = new Mock<IBookService>();
        
        mockService.Setup(x => x.BorrowBook(It.IsAny<long>()))
            .Throws(new Exception());
        var controller = new BookController(mockService.Object);
        
        var problemResult = controller.BorrowBook(mockBook.Id) as ObjectResult;
        Assert.IsNotNull(problemResult);
        Assert.IsNotNull(problemResult.Value);
        Assert.AreEqual(500, problemResult.StatusCode);
    }
    
    /// <summary>
    /// Tests whether DeliverBook API returns 200 when service executes smoothly.
    /// </summary>
    [TestMethod]
    public void DeliverBook_Ok_Test() {
        var mockBook = BuildMockDto(false);
        var mockService = new Mock<IBookService>();
        
        mockService.Setup(x => x.DeliverBook(It.IsAny<long>()))
            .Returns(mockBook);
        var controller = new BookController(mockService.Object);
        
        var okResult = controller.DeliverBook(mockBook.Id) as OkObjectResult;
        Assert.IsNotNull(okResult);

        var result = okResult.Value as BookDto;
        Assert.IsNotNull(result);
        Assert.AreEqual(mockBook.Id, result.Id);
    }
    
    /// <summary>
    /// Tests whether DeliverBook API returns 500 when an internal exception is thrown.
    /// </summary>
    [TestMethod]
    public void DeliverBook_Problem_Test() {
        var mockBook = BuildMockDto(false);
        var mockService = new Mock<IBookService>();
        
        mockService.Setup(x => x.DeliverBook(It.IsAny<long>()))
            .Throws(new Exception());
        var controller = new BookController(mockService.Object);
        
        var problemResult = controller.DeliverBook(mockBook.Id) as ObjectResult;
        Assert.IsNotNull(problemResult);
        Assert.IsNotNull(problemResult.Value);
        Assert.AreEqual(500, problemResult.StatusCode);
    }
    
    /// <summary>
    /// Tests whether DeleteBook API returns 200 when service executes smoothly.
    /// </summary>
    [TestMethod]
    public void DeleteBook_Ok_Test() {
        var mockBook = BuildMockDto(false);
        var mockService = new Mock<IBookService>();
        
        mockService.Setup(x => x.DeleteBook(It.IsAny<long>()))
            .Returns(mockBook);
        var controller = new BookController(mockService.Object);
        
        var okResult = controller.DeleteBook(mockBook.Id) as OkObjectResult;
        Assert.IsNotNull(okResult);

        var result = okResult.Value as BookDto;
        Assert.IsNotNull(result);
        Assert.AreEqual(mockBook.Id, result.Id);
    }
    
    /// <summary>
    /// Tests whether DeleteBook API returns 500 when an internal exception is thrown.
    /// </summary>
    [TestMethod]
    public void DeleteBook_Problem_Test() {
        var mockBook = BuildMockDto(false);
        var mockService = new Mock<IBookService>();
        
        mockService.Setup(x => x.DeleteBook(It.IsAny<long>()))
            .Throws(new Exception());
        var controller = new BookController(mockService.Object);
        
        var problemResult = controller.DeleteBook(mockBook.Id) as ObjectResult;
        Assert.IsNotNull(problemResult);
        Assert.IsNotNull(problemResult.Value);
        Assert.AreEqual(500, problemResult.StatusCode);
    }

    /// <summary>
    /// Helper method to automate building mock BookDto's.
    /// </summary>
    /// <returns>The BookDto object.</returns>
    private BookDto BuildMockDto(bool borrowed) {
        return new BookDto() {
            Id = 4,
            Title = "Test Book",
            Author = TestUtils.BuildAuthor(),
            Publisher = TestUtils.BuildPublisher(),
            Borrowed = borrowed
        };
    }
    
    /// <summary>
    /// Helper method to automate building the mock BookDto list.
    /// </summary>
    /// <returns>The BookDto list.</returns>
    private IList<BookDto> BuildMockDtoList() {
        return new List<BookDto>() {
            BuildMockDto(true),
            BuildMockDto(false)
        };
    }
}