using KantarBooks.DataServer.Service;
using Microsoft.AspNetCore.Mvc;

namespace KantarBooks.DataServer.Controllers;

/// <summary>
/// Controller class for AgentAPI.
/// </summary>
/// <param name="agentService">IAgentService implementation.</param>
[ApiController]
[Route("api/[controller]")]
public class AgentController(IAgentService agentService) : Controller {
    /// <summary>
    /// The IAgentService instance.
    /// </summary>
    private IAgentService _agentService => agentService;
    
    /// <summary>
    /// Returns the list of authors and the list of publishers.
    /// </summary>
    /// <returns>Ok upon success</returns>
    [HttpGet]
    public IActionResult GetAgents() {
        return Ok(_agentService.GetAgents());
    }
}