namespace Models;

/// <summary>
/// The data model for our users.
/// </summary>
public class User
{
    /// <summary>
    /// The user's handle.
    /// </summary>
    public string Username { get; set; } = "";
    /// <summary>
    /// The password, stored as hashed bytes.
    /// </summary>
    public byte[] Password { get; set; } = new byte[] { };
    /// <summary>
    /// The password salt, stored as raw bytes.
    /// </summary>
    public byte[] Salt { get; set; } = new byte[] { };
    /// <summary>
    /// The name of the hashing algorithm used. We keep this info around for compatibility with multiple algorithms.
    /// </summary>
    public string Algorithm { get; set; } = "none";
}
public class RegisterData
{
    /// <summary>
    /// The new user's username.
    /// </summary>
    public string Username { get; set; } = "";
    /// <summary>
    /// The plaintext password to register the user with.
    /// </summary>
    public string Password { get; set; } = "";
}