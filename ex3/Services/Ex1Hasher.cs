namespace Services;
using System.Text;
using System.Security.Cryptography;
/// <summary>
/// Implements the requirements for exercise 1: a "simple" hashing method. We picked MF5 here precisely because it is "simple" and not recommended.
/// </summary>
public class Ex1Hasher : IHasher
{
    private MD5 md5 = MD5.Create();
    private Random rand = new Random();
    public byte[] Hash(string password, byte[] salt)
    {
        var saltedPassword = Encoding.UTF8.GetBytes(password).Concat(salt).ToArray();
        return md5.ComputeHash(saltedPassword);
    }

    public byte[] ProduceSalt()
    {
        byte[] buf = new byte[32];
        rand.NextBytes(buf);
        return buf;
    }

    public bool Verify(string password, byte[] salt, byte[] hash)
    {
        return Hash(password, salt) == hash;
    }
}