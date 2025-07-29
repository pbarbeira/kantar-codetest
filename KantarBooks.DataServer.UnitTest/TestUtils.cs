using KantarBooks.DataServer.Data;
using KantarBooks.DataServer.Models;
using Moq;

namespace KantarBooks.DataServer.UnitTest;

/// <summary>
/// Utility class for DataServer.UnitTests.
/// </summary>
public class TestUtils {
    /// <summary>
    /// Creates a default Author instance.
    /// </summary>
    /// <returns>The default Author instance.</returns>
    public static Author BuildAuthor() {
        return new Author {
            Code = "Author",
            Name = "Author"
        };
    }

    /// <summary>
    /// Creates a default Publisher instance.
    /// </summary>
    /// <returns>The default Publisher instance.</returns>
    public static Publisher BuildPublisher() {
        return new Publisher() {
            Code = "Publisher",
            Name = "Publisher"
        };
    }
    /// <summary>
    /// Helper method to automate building mock BookDto's.
    /// </summary>
    /// <returns>The built BookDto object.</returns>
    public static BookDto BuildMockDto(bool borrowed) {
        return new BookDto() {
            Id = 4,
            Title = "Test Book",
            Author = TestUtils.BuildAuthor(),
            Publisher = TestUtils.BuildPublisher(),
            Borrowed = borrowed
        };
    }
    
    /// <summary>
    /// Helper method to automate building the mock BookDto list.
    /// </summary>
    /// <returns>The built BookDto list.</returns>
    public static IList<BookDto> BuildMockDtoList() {
        return new List<BookDto>() {
            BuildMockDto(true),
            BuildMockDto(false)
        };
    }
}