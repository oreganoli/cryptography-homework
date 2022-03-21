namespace Exceptions;

public class AppException : Exception
{
    /// <summary>
    /// HTTP error code to return for the category of error.
    /// </summary>
    public virtual int Code { get { return StatusCodes.Status500InternalServerError; } }
}

public class WrongOldPasswordException : AppException
{
    public override int Code { get { return StatusCodes.Status401Unauthorized; } }
    public override string Message => "The old password provided was invalid.";
}

public class NoSuchUserException : AppException
{
    public override int Code { get { return StatusCodes.Status404NotFound; } }
    public string Username { get; set; } = "";

    public NoSuchUserException(string username)
    {
        Username = username;
    }
    public override string Message => $"The user {Username} does not exist";
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

public class UnauthorizedException : AppException
{
    public override int Code { get { return StatusCodes.Status401Unauthorized; } }
    public override string Message => "You are not logged in or your JWT was malformed.";
}