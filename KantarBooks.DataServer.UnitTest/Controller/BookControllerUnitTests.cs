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
        var mockList = TestUtils.BuildMockDtoList();
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
    public void AddOrUpdateBook_BadRequestNoTitle_Test() {
        var mockBook = TestUtils.BuildMockDto(false);
        var mockService = new Mock<IBookService>();
        mockBook.Title = "";
        
        mockService.Setup(x => x.AddOrUpdateBook(It.IsAny<BookDto>()))
            .Returns(mockBook);
        var controller = new BookController(mockService.Object);
        
        var badRequestResult = controller.AddOrUpdateBook(mockBook) as BadRequestObjectResult;
        Assert.IsNotNull(badRequestResult);
    }

    /// <summary>
    /// Tests whether AddOrUpdateBook API returns 200 when service executes smoothly.
    /// </summary>
    [TestMethod]
    public void AddOrUpdateBook_BadRequestNoAuthor_Test() {
        var mockBook = TestUtils.BuildMockDto(false);
        var mockService = new Mock<IBookService>();
        mockBook.Author = new();
        
        mockService.Setup(x => x.AddOrUpdateBook(It.IsAny<BookDto>()))
            .Returns(mockBook);
        var controller = new BookController(mockService.Object);
        
        var badRequestResult = controller.AddOrUpdateBook(mockBook) as BadRequestObjectResult;
        Assert.IsNotNull(badRequestResult);
    }
    
    /// <summary>
    /// Tests whether AddOrUpdateBook API returns 200 when service executes smoothly.
    /// </summary>
    [TestMethod]
    public void AddOrUpdateBook_BadRequestNoPublisher_Test() {
        var mockBook = TestUtils.BuildMockDto(false);
        var mockService = new Mock<IBookService>();
        mockBook.Publisher = new();
        
        mockService.Setup(x => x.AddOrUpdateBook(It.IsAny<BookDto>()))
            .Returns(mockBook);
        var controller = new BookController(mockService.Object);
        
        var badRequestResult = controller.AddOrUpdateBook(mockBook) as BadRequestObjectResult;
        Assert.IsNotNull(badRequestResult);
    }
    
    /// <summary>
    /// Tests whether AddOrUpdateBook API returns 200 when service executes smoothly.
    /// </summary>
    [TestMethod]
    public void AddOrUpdateBook_Ok_Test() {
        var mockBook = TestUtils.BuildMockDto(false);
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
        var mockBook = TestUtils.BuildMockDto(false);
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
    public void BorrowBook_BadRequest_Test() {
        var mockService = new Mock<IBookService>();
        var controller = new BookController(mockService.Object);
        
        var badRequestResult = controller.BorrowBook(0) as BadRequestObjectResult;
        Assert.IsNotNull(badRequestResult);
    }
    
    /// <summary>
    /// Tests whether BorrowBook API returns 200 when service executes smoothly.
    /// </summary>
    [TestMethod]
    public void BorrowBook_Ok_Test() {
        var mockBook = TestUtils.BuildMockDto(false);
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
        var mockBook = TestUtils.BuildMockDto(false);
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
    /// Tests whether DeliverBook API returns 400 when model isn't valid.
    /// </summary>
    [TestMethod]
    public void DeliverBook_BadRequest_Test() {
        var mockService = new Mock<IBookService>();
        var controller = new BookController(mockService.Object);
        
        var badRequestResult = controller.DeliverBook(0) as BadRequestObjectResult;
        Assert.IsNotNull(badRequestResult);
    }
    
    /// <summary>
    /// Tests whether DeliverBook API returns 200 when service executes smoothly.
    /// </summary>
    [TestMethod]
    public void DeliverBook_Ok_Test() {
        var mockBook = TestUtils.BuildMockDto(false);
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
        var mockBook = TestUtils.BuildMockDto(false);
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
    /// Tests whether DeleteBook API returns 400 when model isn't valid.
    /// </summary>
    [TestMethod]
    public void DeleteBook_BadRequest_Test() {
        var mockService = new Mock<IBookService>();
        var controller = new BookController(mockService.Object);
        
        var badRequestResult = controller.DeleteBook(0) as BadRequestObjectResult;
        Assert.IsNotNull(badRequestResult);
    }
    
    /// <summary>
    /// Tests whether DeleteBook API returns 200 when service executes smoothly.
    /// </summary>
    [TestMethod]
    public void DeleteBook_Ok_Test() {
        var mockBook = TestUtils.BuildMockDto(false);
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
        var mockBook = TestUtils.BuildMockDto(false);
        var mockService = new Mock<IBookService>();
        
        mockService.Setup(x => x.DeleteBook(It.IsAny<long>()))
            .Throws(new Exception());
        var controller = new BookController(mockService.Object);
        
        var problemResult = controller.DeleteBook(mockBook.Id) as ObjectResult;
        Assert.IsNotNull(problemResult);
        Assert.IsNotNull(problemResult.Value);
        Assert.AreEqual(500, problemResult.StatusCode);
    }
}