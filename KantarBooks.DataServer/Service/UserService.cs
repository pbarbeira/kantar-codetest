using KantarBooks.DataServer.Data;
using KantarBooks.DataServer.Model.Agent;

namespace KantarBooks.DataServer.Service;

public class UserService(IUnitOfWork unitOfWork) : IUserService
{
    private IUnitOfWork _unitOfWork => unitOfWork;
    
    public IList<User> GetUsers()
    {
        return _unitOfWork.UserRepository
            .GetAll()
            .ToList();
    }

    public IList<Author> GetAuthors() {
        return _unitOfWork.Authors.Values.ToList();
    }
    public IList<Publisher> GetPublishers() {
        return _unitOfWork.Publishers.Values.ToList();
    }

    public User? GetUser(string code)
    {
        return _unitOfWork.UserRepository.GetUser(code);
    }
}