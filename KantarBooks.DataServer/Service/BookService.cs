using KantarBooks.DataServer.Data;
using KantarBooks.DataServer.Models;

namespace KantarBooks.DataServer.Service;

public class BookService(IUnitOfWork unitOfWork) : IBookService {
    private IUnitOfWork _unitOfWork => unitOfWork;

    private Book GetBookById(long id) {
        var book = _unitOfWork.BookRepository.GetBookById(id);
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
            return TypeConverter.BookToDto(_unitOfWork.LoadPublisherAndAuthorData(result));
        }
        throw new Exception("Could not add or update book.");
    }
    
    public BookDto BorrowBook(long id) {    
        var book = GetBookById(id);
        if (book.Borrowed) {
            throw new Exception("Error: can't borrow a book that's already borrowed.");
        }
        book.Borrowed = true;
        var result = _unitOfWork.BookRepository.AddOrUpdateBook(book);
        return TypeConverter.BookToDto(_unitOfWork.LoadPublisherAndAuthorData(result!));
    }
    
    public BookDto DeliverBook(long id) {
        var book = GetBookById(id);
        if (!book.Borrowed) {
            throw new Exception("Error: can't borrow a book that's already borrowed.");
        }
        book.Borrowed = false;
        var result = _unitOfWork.BookRepository.AddOrUpdateBook(book);
        return TypeConverter.BookToDto(_unitOfWork.LoadPublisherAndAuthorData(result!));
    }

    public BookDto DeleteBook(long id) {
        var book = _unitOfWork.BookRepository.DeleteBook(id);
        if (book != null) {
            return TypeConverter.BookToDto(book);
        }
        throw new Exception("Book could not be found");
    }
}