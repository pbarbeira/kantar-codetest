namespace KantarBooks.DataServer.Models;

/// <summary>
/// Base class for Agent type entities.
/// We considered it was worthy to separate Agent and Publishers in two
/// different classes since they represent two conceptually different
/// business entities.
/// </summary>
public class Agent {
    public string Code { get; set; } = "";
    public string Name { get; set; } = "";
};

/// <summary>
/// Represents an author in the system.
/// </summary>
public class Author : Agent{}

/// <summary>
/// Represents a publisher in the system.
/// </summary>
public class Publisher : Agent{}