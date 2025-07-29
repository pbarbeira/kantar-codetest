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
    
}