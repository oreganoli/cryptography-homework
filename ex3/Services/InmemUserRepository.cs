namespace Services;
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
            throw new InvalidOperationException($"The user {data.Username} already exists.");
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
}