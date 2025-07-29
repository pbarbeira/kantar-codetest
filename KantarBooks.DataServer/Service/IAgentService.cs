using KantarBooks.DataServer.Models;

namespace KantarBooks.DataServer.Service;

/// <summary>
/// Interface for the AgentService class.
/// </summary>
public interface IAgentService {
    /// <summary>
    /// Returns an AgentDto object containing all the authors and publishers
    /// present in the system..
    /// </summary>
    /// <returns>An AgentDto object with the agent information.</returns>
    AgentDto GetAgents();
}