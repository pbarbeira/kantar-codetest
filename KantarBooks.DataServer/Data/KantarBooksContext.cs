using KantarBooks.DataServer.Config;
using KantarBooks.DataServer.Models;
using Microsoft.EntityFrameworkCore;

namespace KantarBooks.DataServer.Data;

/// <summary>
/// Handles database connection and operations.
/// </summary>
public class KantarBooksContext : DbContext {
    public DbSet<Book> Books { get; set;}

    /// <summary>
    /// Builds the SqlServer connection string from the configuration file.
    /// </summary>
    /// <param name="config">The configuration file.</param>
    /// <returns>The resulting SqlServer connection string.</returns>
    public static string BuildConnectionString(DbConfig config) {
        return $"Server={config.Host},{config.Port};" +
               $"Database={config.Database};" +
               $"User Id={config.User};" +
               $"Password={config.Password};" +
               $"TrustServerCertificate={config.TrustServerCertificate};";
    }

    /// <summary>
    /// Base constructor for KantarBookContext.
    /// </summary>
    /// <param name="options">Options object used by DI container.</param>
    public KantarBooksContext(DbContextOptions<KantarBooksContext> options)
        : base(options) { }
}
