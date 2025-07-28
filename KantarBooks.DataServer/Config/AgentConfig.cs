using KantarBooks.DataServer.Model.Agent;

namespace KantarBooks.DataServer.Config;

public class AgentConfig {
    public IList<Author> Authors { get; set; } = new List<Author>();
    public IList<Publisher> Publishers { get; set; } = new  List<Publisher>();
}