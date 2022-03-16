namespace Services;
using Models;
/// <summary>
/// Interface defining user data functionality.
/// </summary>
public interface IUserRepository
{
    /// <summary>
    /// Returns a list of all registered usernames.
    /// </summary>
    /// <returns>List of all usernames.</returns>
    List<string> GetAllUsers();

    /// <summary>
    /// Registers a new user.
    /// </summary>
    /// <param name="data">Registration data.</param>
    void RegisterUser(RegisterData data);

    /// <summary>
    /// Checks if a user with the given username already exists.
    /// </summary>
    /// <param name="username">Username to search for.</param>
    /// <returns>True or false.</returns>
    bool UserExists(string username);

    /// <summary>
    /// Attempts to log a user in.
    /// </summary>
    /// <param name="username">The user's username.</param>
    /// <param name="password">The user's password.</param>
    /// <returns>Whether or not the username + password combination is valid.</returns>
    bool Authenticate(string username, string password);
}