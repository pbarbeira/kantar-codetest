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
        try {
            return Ok(_bookService.AddOrUpdateBook(book));
        }
        catch (Exception e) {
            return Problem(e.Message);
        }
    }

    /// <summary>
    /// Registers a book as borrowed by storing in the database the code of
    /// the user that borrowed the book.
    /// </summary>
    /// <param name="id">The id of the book to be borrowed.</param>
    /// <returns>Ok upon success</returns>
    [HttpPost("{id}/borrow")]
    public IActionResult BorrowBook([FromRoute] long id) {
        try {
            return Ok(_bookService.BorrowBook(id));
        }
        catch (Exception e) {
            return Problem(e.Message);
        }
    }
    
    /// <summary>
    /// Registers the return of the book by removing the user code from the
    /// book instance of the database.
    /// </summary>
    /// <param name="id">The id of the book to be returned.</param>
    /// <returns>Ok upon success.</returns>
    [HttpPost("{id}/deliver")]
    public IActionResult DeliverBook([FromRoute] long id) {
        try {
            return Ok(_bookService.DeliverBook(id));
        }
        catch (Exception e) {
            return Problem(e.Message);
        }
    }
    
    /// <summary>
    /// Deletes a book from the system.
    /// </summary>
    /// <param name="id">The id of the book to be deleted.</param>
    /// <returns>Ok upon success.</returns>
    [HttpDelete("{id}")]
    public IActionResult DeleteBook([FromRoute] long id) {
        try {
            var result = _bookService.DeleteBook(id);
            return Ok(result);
        }
        catch (Exception e) {
            return Problem(e.Message);
        }
    }
}