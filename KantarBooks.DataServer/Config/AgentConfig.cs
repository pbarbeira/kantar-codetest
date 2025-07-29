using KantarBooks.DataServer.Models;

namespace KantarBooks.DataServer.Config;

/// <summary>
/// Agents Configuration file. Used to load the Authors and Publishers lists from
/// a .json file using .net's built in IConfiguration property.
/// </summary>
public class AgentConfig {
    /// <summary>
    /// The list of authors.
    /// </summary>
    public IList<Author> Authors { get; set; } = new List<Author>();
    
    /// <summary>
    /// The list of publishers.
    /// </summary>
    public IList<Publisher> Publishers { get; set; } = new  List<Publisher>();
}