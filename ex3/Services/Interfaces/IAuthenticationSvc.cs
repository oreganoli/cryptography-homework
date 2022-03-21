namespace Services;

/// <summary>
/// Interface for the authentication service.
/// </summary>
public interface IAuthenticationSvc
{
    /// <summary>
    /// Tries to get a JWT from the HTTP context and return the claimed username.
    /// </summary>
    public string? TryGetUsernameFromJwt(HttpContext ctx);
    /// <summary>
    /// Gets a username from a JWT or throws an exception.
    /// </summary>
    public string GetUsernameFromJwt(HttpContext ctx);
    /// <summary>
    /// Generates a JWT claiming the given username.
    /// </summary>
    public string GetJwtForUsername(string username);
}