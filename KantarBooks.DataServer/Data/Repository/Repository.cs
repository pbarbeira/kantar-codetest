namespace KantarBooks.DataServer.Data.Repository;

/// <summary>
/// Abstract Repository class. Contains common methods that will likely be used
/// in most (if not all) instances.
/// </summary>
/// <typeparam name="T">The model base that the repository portrays to.</typeparam>
public abstract class Repository<T> : IDisposable {
    protected readonly KantarBooksContext _context;

    public Repository(KantarBooksContext context) {
        _context = context;
    }
    
    public void Dispose() {
        _context.Dispose();
    }
}