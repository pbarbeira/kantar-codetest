using KantarBooks.DataServer.Data;
using KantarBooks.DataServer.Models;

namespace KantarBooks.DataServer.Service;

public class AgentService(IUnitOfWork unitOfWork) : IAgentService {
    private IUnitOfWork _unitOfWork = unitOfWork;
    
    public AgentDto GetAgents() {
        return new AgentDto() {
            Authors = _unitOfWork.Authors.Values.ToList(),
            Publishers = _unitOfWork.Publishers.Values.ToList()
        };
    }
}