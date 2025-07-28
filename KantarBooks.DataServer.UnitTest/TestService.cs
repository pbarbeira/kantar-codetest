using KantarBooks.DataServer.DataAccess;
using Moq;

namespace KantarBooks.DataServer.UnitTest;

public class TestUtils {
    public static Mock<T> BuildMock<T>() where T : class {
        return new Mock<T>();
    }
    
    public static IUnitOfWork BuildUnitOfWork()
    {
        return BuildMock<UnitOfWork>().Object;
    }
    
    
}