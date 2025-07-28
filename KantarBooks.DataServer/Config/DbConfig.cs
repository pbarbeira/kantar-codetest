namespace KantarBooks.DataServer.Config;

public class DbConfig {
    public DbType DbType { get; set; }
    public string Host { get; set; }
    public int Port { get; set; }
    public string Database { get; set; }
    public string User { get; set; }
    public string Password { get; set; }
    public string TrustServerCertificate { get; set; }
}

public enum DbType {
    SQLITE, SQLSVR
}