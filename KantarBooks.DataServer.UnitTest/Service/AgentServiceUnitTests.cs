using KantarBooks.DataServer.Data;
using KantarBooks.DataServer.Models;
using KantarBooks.DataServer.Service;
using Moq;

namespace KantarBooks.DataServer.UnitTest.Service;

/// <summary>
/// Test class for AgentService.
/// </summary>
[TestClass]
public sealed class AgentServiceUnitTests {
    /// <summary>
    /// Tests whether the GetAgents method takes the agent data stored in the
    /// system and converts it to an AgentDto object.
    /// </summary>
    [TestMethod]
    public void GetAgents_Test() {
        var mockUnitOfWork = new Mock<IUnitOfWork>();
        mockUnitOfWork.Setup(x => x.Authors).Returns(BuildAuthorDictionary());
        mockUnitOfWork.Setup(x => x.Publishers).Returns(BuildPublisherDictionary);
        
        var service = new AgentService(mockUnitOfWork.Object);
        
        var result = service.GetAgents();
        Assert.IsNotNull(result);
        Assert.AreEqual(1, result.Authors.Count());
        Assert.AreEqual(1, result.Publishers.Count());
    }

    /// <summary>
    /// Helper method to automate building the Authors dictionary.
    /// </summary>
    /// <returns></returns>
    private IDictionary<string, Author> BuildAuthorDictionary() {
        return new Dictionary<string, Author> {{
                "Author", TestUtils.BuildAuthor()
        }};
    }
    
    /// <summary>
    /// Helper method to automate building the Publishers dictionary.
    /// </summary>
    /// <returns></returns>
    private IDictionary<string, Publisher> BuildPublisherDictionary() {
        return new Dictionary<string, Publisher> {{
            "Publisher", TestUtils.BuildPublisher()
        }};
    }
 
}