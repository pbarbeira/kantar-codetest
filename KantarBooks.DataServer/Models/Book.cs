using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KantarBooks.DataServer.Models;

/// <summary>
/// Book model for KantarBooks books. Acts as schema for EntityFramework.
/// </summary>
public class Book {
    /// <summary>
    /// The id of the book. Handles autoincrement if the database engine
    /// supports it.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// The title of the book.
    /// </summary>
    [MaxLength(255)]
    public string Title { get; set; } = "";

    /// <summary>
    /// The code of the author. Used to match with the appropriate author
    /// object in UnitOfWork.
    /// </summary>
    [MaxLength(50)]
    public string AuthorCode { get; set; } = "";
    /// <summary>
    /// The code's Author. Lazy-loaded by the system.
    /// </summary>
    [NotMapped] public Author Author { get; set; } = new();

    /// <summary>
    /// The code of the author. Used to match with the appropriate author
    /// object in UnitOfWork.
    /// </summary>
    [MaxLength(50)]
    public string PublisherCode { get; set; } = "";

    /// <summary>
    /// The code's Publisher. Lazy-loaded by the system.
    /// </summary>
    [NotMapped]
    public Publisher Publisher { get; set; } = new();

    /// <summary>
    /// Flag indicating whether the book has been borrowed or not.
    /// </summary>
    public bool Borrowed { get; set; }
}