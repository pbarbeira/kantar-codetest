using KantarBooks.DataServer.Model;
using KantarBooks.DataServer.Model.Agent;

namespace KantarBooks.DataServer.Service;

public class TypeConverter {
    public static IList<BookDTO> BookToDto(IList<Book> books) {
        return books.Select(x =>
            new BookDTO {
                Code = x.Code,
                Name = x.Name,
                Author = x.Author,
                Publisher = x.Publisher,
                Borrower = x.Borrower ?? new User()
            }
        ).ToList();
    }
    
}