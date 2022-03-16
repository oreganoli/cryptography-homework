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