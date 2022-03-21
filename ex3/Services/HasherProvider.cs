namespace Services;
using Exceptions;
public class HasherProvider : IHasherProvider
{
    private Ex1Hasher simpleHasher;
    private Ex2Hasher properHasher;

    public HasherProvider(Ex1Hasher simpleHasher, Ex2Hasher properHasher)
    {
        this.simpleHasher = simpleHasher;
        this.properHasher = properHasher;
    }

    public IHasher GetHasher(string algorithm)
    {
        switch (algorithm)
        {
            case "ex1":
                return simpleHasher;
            case "ex2":
                return properHasher;
            default:
                throw new UnsupportedAlgorithmException(algorithm);
        }
    }
}