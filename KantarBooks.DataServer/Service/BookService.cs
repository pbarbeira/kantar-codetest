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
        throw new Exception("Book could not be added or updated");
    }
    
    public BookDto BorrowBook(long id) {
        var book = GetBookById(id);
        book.Borrowed = true;
        var result = _unitOfWork.BookRepository.AddOrUpdateBook(book);
        return TypeConverter.BookToDto(_unitOfWork.LoadPublisherAndAuthorData(result!));
    }
    
    public BookDto DeliverBook(long id) {
        var book = GetBookById(id);
        book.Borrowed = false;
        var result = _unitOfWork.BookRepository.AddOrUpdateBook(book);
        return TypeConverter.BookToDto(_unitOfWork.LoadPublisherAndAuthorData(result!));
    }

    public BookDto DeleteBook(long id) {
        return TypeConverter.BookToDto(_unitOfWork.BookRepository.DeleteBook(id)!);
    }
}