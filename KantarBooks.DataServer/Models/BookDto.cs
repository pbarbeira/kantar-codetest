namespace KantarBooks.DataServer.Models;

/// <summary>
/// Book DTO. Used to pass information between the frontend and the backend.
/// </summary>
public class BookDto {
    /// <summary>
    /// The book's id.
    /// </summary>
    public long Id { get; set; }
    
    /// <summary>
    /// The book's title.
    /// </summary>
    public string Title { get; set; } = "";
    
    /// <summary>
    /// The book's author.
    /// </summary>
    public Author Author { get; set; } = new();
    
    /// <summary>
    /// The book's publisher.
    /// </summary>
    public Publisher Publisher { get; set; } = new();

    /// <summary>
    /// Indicates if the book has been borrowed.
    /// </summary>
    public bool Borrowed { get; set; }
}