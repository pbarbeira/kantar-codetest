using KantarBooks.DataServer.Model;
using KantarBooks.DataServer.Model.Agent;

namespace KantarBooks.DataServer.Service;

public interface IBookService
{
    IList<BookDTO> GetBooks();
    BookDTO AddOrUpdateBook(BookDTO book);
    BookDTO DeleteBook(BookDTO book);
    BookDTO BorrowBook(BookDTO book, UserDTO user);
    BookDTO DeliverBook(BookDTO book, UserDTO user);
}