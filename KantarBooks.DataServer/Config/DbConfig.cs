namespace KantarBooks.DataServer.Config;

/// <summary>
/// Database Configuration. Contains the necessary configurations to connect
/// to the database. Reads information from appsettings.json.
/// </summary>
public class DbConfig {
    /// <summary>
    /// The database host.
    /// </summary>
    public string Host { get; set; }
    
    /// <summary>
    /// The database port.
    /// </summary>
    public int Port { get; set; }
    
    /// <summary>
    /// The database name.
    /// </summary>
    public string Database { get; set; }
    
    /// <summary>
    /// The database server's user credential.
    /// </summary>
    public string User { get; set; }
    
    /// <summary>
    /// The database server's password credential.
    /// </summary>
    public string Password { get; set; }
    
    /// <summary>
    /// Configures database to accept remote requests.
    /// </summary>
    public string TrustServerCertificate { get; set; }
}