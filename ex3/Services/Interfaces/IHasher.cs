namespace Services;

public interface IHasher
{
    /// <summary>
    /// Produce a hash given a plaintext password and a cryptographic salt.
    /// </summary>
    /// <param name="password">Password, in plaintext.</param>
    /// <param name="salt">Salt, as a byte array.</param>
    /// <returns>A salted hash as a byte array.</returns>
    byte[] Hash(string password, byte[] salt);
    /// <summary>
    /// Generates a new cryptographic salt as a byte array.
    /// </summary>
    /// <returns>A salt.</returns>
    byte[] ProduceSalt();
    /// <summary>
    /// Convenience method for quickly verifying a plaintext password against a salt and hash.
    /// </summary>
    /// <param name="password">Password.</param>
    /// <param name="salt">Salt.</param>
    /// <param name="hash">Hash.</param>
    /// <returns>Whether or not the password, concatenated with the salt, produces the given output hash.</returns>
    bool Verify(string password, byte[] salt, byte[] hash);
}