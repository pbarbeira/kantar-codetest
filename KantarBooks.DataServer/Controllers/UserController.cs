using KantarBooks.DataServer.Service;
using Microsoft.AspNetCore.Mvc;

namespace KantarBooks.DataServer.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : Controller{
    private IUserService _userService;

    public UserController(IUserService userService) {
        _userService = userService;
    }
    
    [HttpGet]
    public IActionResult GetAll() {
        return Ok(_userService.GetUsers());
    }

    [HttpGet("author")]
    public IActionResult GetAuthors() {
        return Ok(_userService.GetAuthors());
    }

    [HttpGet("publisher")]
    public IActionResult GetPublishers() {
        return Ok(_userService.GetPublishers());
    }
}