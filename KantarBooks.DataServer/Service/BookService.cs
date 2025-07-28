using KantarBooks.DataServer.Data;
using KantarBooks.DataServer.Model;
using KantarBooks.DataServer.Model.Agent;

namespace KantarBooks.DataServer.Service;

public class BookService(IUnitOfWork unitOfWork) : IBookService {
    private IUnitOfWork _unitOfWork => unitOfWork;

    public IList<BookDTO> GetBooks() {
        var books = _unitOfWork.GetBooks().ToList();
        return TypeConverter.BookToDto(books).ToList();
    }
    
    public BookDTO AddOrUpdateBook(BookDTO book) {
        throw new NotImplementedException();
    }

    public BookDTO DeleteBook(BookDTO book) {
        throw new NotImplementedException();
    }

    public BookDTO BorrowBook(BookDTO book, UserDTO user) {
        throw new NotImplementedException();
    }

    public BookDTO DeliverBook(BookDTO book, UserDTO user) {
        throw new NotImplementedException();
    }
}