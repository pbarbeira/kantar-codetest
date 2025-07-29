using KantarBooks.DataServer.Models;
using KantarBooks.DataServer.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KantarBooks.DataServer.Controllers;

/// <summary>
/// Controller class for the BookAPI
/// </summary>
/// <param name="bookService">IBookService implementation</param>
[ApiController]
[Route("api/[controller]")]
public class BookController(IBookService bookService) : Controller{
    /// <summary>
    /// The IBookService instance.
    /// </summary>
    private IBookService _bookService => bookService;
    
    /// <summary>
    /// Returns the Book data stored in the system.
    /// </summary>
    /// <returns>Ok upon success</returns>
    [HttpGet]
    // [Authorize]
    public IActionResult GetAll() {
        return Ok(_bookService.GetBooks());
    }

    /// <summary>
    /// Adds a Book to the system. If there's already a book with the same
    /// code, updates said book's information.
    /// </summary>
    /// <param name="book">The BookDto with the new book information.</param>
    /// <returns>Ok upon success</returns>
    [HttpPost]
    public IActionResult AddOrUpdateBook([FromBody] BookDto book) {
        book.Code = book.Code == "" ? "new code" : book.Code;
        return Ok(book);
    }

    /// <summary>
    /// Registers a book as borrowed by storing in the database the code of
    /// the user that borrowed the book.
    /// </summary>
    /// <param name="bookCode">The coode of the book to be borrowed.</param>
    /// <param name="userCode">The user code of the borrower.</param>
    /// <returns>Ok upon success</returns>
    [HttpPost("{bookCode}/borrow")]
    public IActionResult BorrowBook([FromRoute] string bookCode, [FromBody]  string userCode) {
        return Ok(bookCode);
    }
    
    /// <summary>
    /// Registers the return of the book by removing the user code from the
    /// book instance of the database.
    /// </summary>
    /// <param name="bookCode">The code of the book to be returned.</param>
    /// <param name="userCode">The code of the user that returned the book.</param>
    /// <returns>Ok upon success.</returns>
    [HttpPost("{bookCode}/deliver")]
    public IActionResult DeliverBook([FromRoute] string bookCode, [FromBody] string userCode) {
        return Ok(bookCode);
    }
    
    /// <summary>
    /// Deletes a book from the system.
    /// </summary>
    /// <param name="code">The code of the book to be deleted.</param>
    /// <returns>Ok upon success.</returns>
    [HttpDelete("{code}")]
    public IActionResult DeleteBook([FromRoute] string code) {
        return Ok(code);
    }
}