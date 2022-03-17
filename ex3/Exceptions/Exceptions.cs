namespace Exceptions;
public class UserExistsException : Exception
{
    public string Username { get; set; } = "";

    public UserExistsException(string username)
    {
        Username = username;
    }
    public override string Message => $"The user {Username} already exists";
}
public class LoginFailedException : Exception
{
    public override string Message => "Invalid username/password combination.";
}