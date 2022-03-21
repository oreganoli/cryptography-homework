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

    public void UpsertUser(User user)
    {
        var existentUser = users.Find(x => x.Username == user.Username);
        if (existentUser == null)
        {
            users.Add(user);
        }
        else
        {
            existentUser = user;
        }
    }

    public User? ReadUser(string username)
    {
        return users.Find(x => x.Username == username);
    }

    public void DeleteUser(string username)
    {
        users.RemoveAll(x => x.Username == username);
    }
}