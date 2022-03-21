namespace Services;

public interface IHasherProvider
{
    /// <summary>
    /// Gets the hasher with the specified algorithm.
    /// </summary>
    /// <param name="algorithm">Name of the algorithm to use.</param>
    /// <returns>Reference to an <c>IHasher</c> instance of the appropriate type.</returns>
    IHasher GetHasher(string algorithm);
}