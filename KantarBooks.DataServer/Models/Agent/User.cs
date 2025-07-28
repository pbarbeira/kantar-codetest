namespace KantarBooks.DataServer.Model.Agent;

public class User : UserDTO{
    public long Id { get; set; } = 0;
}

public class UserDTO {
    public string Code { get; set; } = "";
    public string Name { get; set; } = "";
}