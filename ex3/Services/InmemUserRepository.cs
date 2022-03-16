namespace Services;
using Exceptions;
using Models;
using System.Text;
/// <summary>
/// In-memory user repository.
/// </summary>
public class InmemUserRepository : IUserRepository
{
    private List<User> users = new List<User>();

    public bool UserExists(string username)
    {
        return users.Exists(user => user.Username == username);
    }

    public List<string> GetAllUsers()
    {
        return users.Select(each => each.Username).ToList();
    }

    public void RegisterUser(RegisterData data)
    {
        if (UserExists(data.Username))
        {
            throw new UserExistsException(data.Username);
        }
        else
        {
            users.Add(new User
            {
                Algorithm = "none",
                Password = Encoding.UTF8.GetBytes(data.Password),
                Salt = new byte[] { },
                Username = data.Username
            });
        }
    }

    public bool Authenticate(string username, string password)
    {
        // no hashing yet
        var passwordBytes = Encoding.UTF8.GetBytes(password);
        return users.Exists(user => user.Username == username && user.Password.SequenceEqual(passwordBytes));
    }
}