using KantarBooks.DataServer.Controllers;
using KantarBooks.DataServer.Models;
using KantarBooks.DataServer.Service;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace KantarBooks.DataServer.UnitTest.Controller;

/// <summary>
/// Test class for AgentController.
/// </summary>
[TestClass]
public class AgentControllerUnitTests {
    
    /// <summary>
    /// Tests whether the GetAgents API returns the AgentDTO object returned
    /// from the service call.
    /// </summary>
    [TestMethod]
    public void GetAgents_Ok_Test() {
        var mockService = new Mock<IAgentService>();
        mockService.Setup(service => service.GetAgents()).Returns(BuildAgentDto);
        
        var controller = new AgentController(mockService.Object);
        
        var okResult = controller.GetAgents() as OkObjectResult;
        Assert.IsNotNull(okResult);
        
        var result = okResult.Value as AgentDto;
        Assert.IsNotNull(result);
        Assert.AreEqual(result.Authors.Count(), 1);
        Assert.AreEqual(result.Publishers.Count(), 1);
    }

    /// <summary>
    /// Helper method to automate building the AgentDto object.
    /// </summary>
    /// <returns></returns>
    private AgentDto BuildAgentDto() {
        return new AgentDto() {
            Authors = new List<Author>() { TestUtils.BuildAuthor() },
            Publishers = new List<Publisher>() { TestUtils.BuildPublisher() }
        };
    }
    
}