namespace Services;
using Models;
/// <summary>
/// High-level interface for user operations.
/// </summary>
public interface IUserLogic
{
    /// <summary>
    /// List all registered users.
    /// </summary>
    /// <returns>A list of usernames.</returns>
    List<string> ListUsers();

    /// <summary>
    /// Create a new user.
    /// </summary>
    /// <param name="username">The username to register the user under.</param>
    /// <param name="password">The user's password.</param>
    /// <param name="hashMethod">The hashing method to use.</param>
    void Register(string username, string password, string hashMethod);
    /// <summary>
    /// Validate a user's username/password combination.
    /// </summary>
    /// <param name="username">The username.</param>
    /// <param name="password">The password.</param>
    /// <returns>Whether or not the username/password pair is correct.</returns>
    bool Validate(string username, string password);
    /// <summary>
    /// Changes a user's password at their request.
    /// </summary>
    /// <param name="username">The user's username.</param>
    /// <param name="oldPassword">The old password.</param>
    /// <param name="newPassword">The new password.</param>
    void ChangePassword(string username, string oldPassword, string newPassword);
    /// <summary>
    /// Deletes a user account.
    /// </summary>
    /// <param name="username">The name of the account to delete.</param>
    void DeleteAccount(string username);
}