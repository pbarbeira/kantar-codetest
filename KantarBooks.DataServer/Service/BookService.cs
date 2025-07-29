using KantarBooks.DataServer.Data;
using KantarBooks.DataServer.Models;

namespace KantarBooks.DataServer.Service;

public class BookService(IUnitOfWork unitOfWork) : IBookService {
    private IUnitOfWork _unitOfWork => unitOfWork;

    public IList<BookDto> GetBooks() {
        var books = _unitOfWork.GetBooks().ToList();
        return TypeConverter.BookToDto(books).ToList();
    }
    
    public BookDto AddOrUpdateBook(BookDto book) {
        throw new NotImplementedException();
    }

    public BookDto DeleteBook(BookDto book) {
        throw new NotImplementedException();
    }

    public BookDto BorrowBook(BookDto book, string userCode) {
        throw new NotImplementedException();
    }

    public BookDto DeliverBook(BookDto book, string userCode) {
        throw new NotImplementedException();
    }
}