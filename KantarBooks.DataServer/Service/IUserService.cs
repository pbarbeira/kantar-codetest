using KantarBooks.DataServer.Model.Agent;

namespace KantarBooks.DataServer.Service;

public interface IUserService {
    IList<User> GetUsers();
    IList<Author> GetAuthors();
    IList<Publisher> GetPublishers();
    User? GetUser(string code);
}