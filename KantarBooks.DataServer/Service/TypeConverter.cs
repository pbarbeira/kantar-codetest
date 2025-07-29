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
    public static IList<BookDto> BookToDto(IList<Book> books) {
        return books.Select(x =>
            new BookDto {
                Code = x.Code,
                Title = x.Title,
                Author = x.Author,
                Publisher = x.Publisher,
                Borrower = x.Borrower
            }
        ).ToList();
    }
    
}