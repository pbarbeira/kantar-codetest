using KantarBooks.DataServer.Models;

namespace KantarBooks.DataServer.Service;

/// <summary>
/// Type converter class. Contains the different type converterss used
/// throughout the system.
/// </summary>
public class TypeConverter {
    /// <summary>
    /// Converts Book objects to BookDto objects.
    /// </summary>
    /// <param name="books">The list of Book objects to be converted.</param>
    /// <returns>The list of the converted BookDto objects.</returns>
    public static IList<BookDto> BooksToDto(IList<Book> books) {
        return books.Select(x => BookToDto(x)).ToList();
    }

    public static BookDto BookToDto(Book book) {
        return new BookDto {
            Code = book.Code,
            Title = book.Title,
            Author = book.Author,
            Publisher = book.Publisher,
            Borrower = book.Borrower
        };
    }
    
    

    public static Book DtoToBook(BookDto bookDto) {
        return new Book {
            Code = bookDto.Code,
            Title = bookDto.Title,
            AuthorCode = bookDto.Author.Code,
            PublisherCode = bookDto.Publisher.Code,
            Borrower = bookDto.Borrower,
        };
    }
    
}