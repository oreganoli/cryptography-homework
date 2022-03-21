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
    /// Creates a new user or updates an existent one.
    /// </summary>
    /// <param name="user">User data.</param>
    void UpsertUser(User user);
    /// <summary>
    /// Retrieves the data for a given user.
    /// </summary>
    /// <param name="username">The username to retrieve data for.</param>
    /// <returns>User data.</returns>
    User? ReadUser(string username);

    /// <summary>
    /// Checks if a user with the given username already exists.
    /// </summary>
    /// <param name="username">Username to search for.</param>
    /// <returns>True or false.</returns>
    bool UserExists(string username);
}