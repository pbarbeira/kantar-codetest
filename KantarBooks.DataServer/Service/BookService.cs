using KantarBooks.DataServer.Data;
using KantarBooks.DataServer.Models;

namespace KantarBooks.DataServer.Service;

public class BookService(IUnitOfWork unitOfWork) : IBookService {
    private IUnitOfWork _unitOfWork => unitOfWork;

    private Book GetBookByCode(string bookCode) {
        var book = _unitOfWork.BookRepository.GetBookByCode(bookCode);
        if (book != null) {
            return book;
        }
        throw new Exception("Book could not be found.");
    }
    
    public IList<BookDto> GetBooks() {
        var books = _unitOfWork.GetBooks().ToList();
        return TypeConverter.BooksToDto(books).ToList();
    }
    
    public BookDto AddOrUpdateBook(BookDto bookDto) {
        var book = TypeConverter.DtoToBook(bookDto);
        var result = _unitOfWork.BookRepository.AddOrUpdateBook(book);
        if (result != null) {
            return TypeConverter.BookToDto(result);
        }
        throw new Exception("Book could not be added or updated");
    }
    
    public BookDto BorrowBook(string code, string userCode) {
        var book = GetBookByCode(code);
        if (book.Borrower != "") {
            throw new Exception("Error: cannot borrow a book that's already borrowed.");
        }
        book.Borrower = userCode;
        return TypeConverter.BookToDto(_unitOfWork.BookRepository.AddOrUpdateBook(book)!);
    }

    public BookDto DeliverBook(string code, string userCode) {
        var book = GetBookByCode(code);
        if (book.Borrower != userCode) {
            throw new Exception("Error: the borrower code and user code don't match");
        }
        book.Borrower = "";
        return TypeConverter.BookToDto(_unitOfWork.BookRepository.AddOrUpdateBook(book)!);
    }

    public BookDto DeleteBook(string code) {
        var book = GetBookByCode(code);
        return TypeConverter.BookToDto(_unitOfWork.BookRepository.DeleteBook(book)!);
    }
}