using System.ComponentModel.DataAnnotations.Schema;
using KantarBooks.DataServer.Model.Agent;

namespace KantarBooks.DataServer.Model;

public class Book
{
    public int Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    
    public string AuthorCode { get; set; }
    [NotMapped]
    public Author Author { get; set; }
    
    public string PublisherCode { get; set; }
    [NotMapped]
    public Publisher Publisher { get; set; }
    
    public bool Borrowed { get; set; }
    public User? Borrower { get; set; } = null;

    private void BorrowBook(User borrower) {
        Borrowed = true;
        Borrower = borrower;
    }

    private void ReturnBook() {
        Borrowed = false;
        Borrower = null;
    }
}

public class BookDTO {
    public string Code { get; set; }
    public string Name { get; set; }
    public UserDTO Author { get; set; }
    public UserDTO Publisher { get; set; }
    public UserDTO Borrower { get; set; } = new User();
}