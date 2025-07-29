namespace KantarBooks.DataServer.Models;

/// <summary>
/// Data transfer object used to pass agent data to the frontend.
/// </summary>
public class AgentDto {
    /// <summary>
    /// List containing the author data.
    /// </summary>
    public IList<Author> Authors { get; set; } = new List<Author>();
    
    /// <summary>
    /// List containing the publisher data.
    /// </summary>
    public IList<Publisher> Publishers { get; set; } = new List<Publisher>();
}