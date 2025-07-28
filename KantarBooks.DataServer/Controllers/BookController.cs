using KantarBooks.DataServer.Model;
using KantarBooks.DataServer.Model.Agent;
using KantarBooks.DataServer.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KantarBooks.DataServer.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookController(IBookService bookService) : Controller{
    private IBookService _bookService => bookService;
    
    [HttpGet]
    // [Authorize]
    public IActionResult GetAll() {
        return Ok(_bookService.GetBooks());
    }

    [HttpPost]
    public IActionResult AddOrUpdateBook([FromBody] BookDTO book) {
        book.Code = book.Code == "" ? "new code" : book.Code;
        return Ok(book);
    }

    [HttpPost("{bookCode}/borrow")]
    public IActionResult BorrowBook([FromRoute] string bookCode, [FromBody]  string userCode) {
        return Ok(bookCode);
    }
    
    [HttpPost("{bookCode}/deliver")]
    public IActionResult DeliverBook([FromRoute] string bookCode, [FromBody] string userCode) {
        return Ok(bookCode);
    }
    
    [HttpDelete("{code}")]
    public IActionResult DeleteBook([FromRoute] string code) {
        return Ok(code);
    }
}