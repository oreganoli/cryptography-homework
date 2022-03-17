namespace Exceptions;

public class AppException : Exception
{
    /// <summary>
    /// HTTP error code to return for the category of error.
    /// </summary>
    public virtual int Code { get { return StatusCodes.Status500InternalServerError; } }
}

public class UserExistsException : AppException
{
    public override int Code { get { return StatusCodes.Status409Conflict; } }
    public string Username { get; set; } = "";

    public UserExistsException(string username)
    {
        Username = username;
    }
    public override string Message => $"The user {Username} already exists";
}
public class LoginFailedException : AppException
{
    public override int Code { get { return StatusCodes.Status404NotFound; } }
    public override string Message => "Invalid username/password combination.";
}