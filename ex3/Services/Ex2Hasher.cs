namespace Services;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
public class Ex2Hasher : IHasher
{
    private const int ITERATION_COUNT = 2000;
    private const int HASH_SIZE = 128;
    private Random rand = new Random();
    public byte[] Hash(string password, byte[] salt)
    {
        return KeyDerivation.Pbkdf2(password, salt, KeyDerivationPrf.HMACSHA256, ITERATION_COUNT, HASH_SIZE);
    }

    public byte[] ProduceSalt()
    {
        byte[] buf = new byte[64];
        rand.NextBytes(buf);
        return buf;
    }

    public bool Verify(string password, byte[] salt, byte[] hash)
    {
        return Hash(password, salt).SequenceEqual(hash);
    }
}
