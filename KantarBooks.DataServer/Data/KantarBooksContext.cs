using KantarBooks.DataServer.Config;
using KantarBooks.DataServer.Model;
using KantarBooks.DataServer.Model.Agent;
using Microsoft.EntityFrameworkCore;

namespace KantarBooks.DataServer.Data;

/// <summary>
/// Handles database connection and operations.
/// </summary>
public class KantarBooksContext : DbContext {
    public DbSet<Book> Books { get; set;}
    public DbSet<User> Users { get; set;}

    public static string BuildConnectionString(DbConfig config) {
        return $"Server={config.Host},{config.Port};" +
               $"Database={config.Database};" +
               $"User Id={config.User};" +
               $"Password={config.Password};" +
               $"TrustServerCertificate={config.TrustServerCertificate};";
    }

    public KantarBooksContext(DbContextOptions<KantarBooksContext> options)
        : base(options) { }
}
