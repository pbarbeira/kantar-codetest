using KantarBooks.DataServer.Config;
using KantarBooks.DataServer.Model.Agent;

namespace KantarBooks.DataServer.Data.Repository;

/// <summary>
/// Handles operations and bookkeeping related to Agent objects.
/// </summary>
public class UserRepository(KantarBooksContext context) 
    : Repository<User>(context), IUserRepository {
    
    public IEnumerable<User> GetAll() {
        return _context.Users.ToList();
    }

    public User? GetUser(string code) {
        return _context.Users.FirstOrDefault(x => x.Code == code);
    }
    
    public User? AddOrUpdateUser(User user) {
        throw new NotImplementedException();
    }
    public User? DeleteUser(string code) {
        throw new NotImplementedException();
    }
}