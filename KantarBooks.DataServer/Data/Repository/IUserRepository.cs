using KantarBooks.DataServer.Model.Agent;

namespace KantarBooks.DataServer.Data.Repository;

/// <summary>
/// Interface class for UserRepository
/// </summary>
public interface IUserRepository : IDisposable {
    
    IEnumerable<User> GetAll();
    User? GetUser(string code);
    User? AddOrUpdateUser(User user);
    User? DeleteUser(string code);
}