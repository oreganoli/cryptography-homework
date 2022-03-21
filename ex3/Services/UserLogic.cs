using Exceptions;
using Models;

namespace Services;

public class UserLogic : IUserLogic
{
    private IUserRepository repo;

    public UserLogic(IUserRepository repo)
    {
        this.repo = repo;
    }

    public void ChangePassword(string username, string oldPassword, string newPassword)
    {
        if (!Validate(username, oldPassword))
        {
            throw new NoSuchUserException(username);
        }
        var user = repo.ReadUser(username) ?? throw new NoSuchUserException(username);
        user.Password = System.Text.Encoding.UTF8.GetBytes(newPassword);
        repo.UpsertUser(user);
    }

    public void DeleteAccount(string username)
    {
        repo.DeleteUser(username);
    }

    public List<string> ListUsers()
    {
        return repo.GetAllUsers();
    }

    public void Register(string username, string password, string hashMethod)
    {
        if (repo.UserExists(username))
        {
            throw new UserExistsException(username);
        }
        // TODO: actual hashing
        var userData = new User
        {
            Algorithm = "TODO",
            Password = System.Text.Encoding.UTF8.GetBytes(password), // TODO
            Salt = new byte[] { }, // TODO
            Username = username
        };
        repo.UpsertUser(userData);
    }

    public bool Validate(string username, string password)
    {
        // TODO: hashing.
        var user = repo.ReadUser(username);
        if (user == null)
        {
            return false;
        }
        return user.Password.SequenceEqual(System.Text.Encoding.UTF8.GetBytes(password)); // TODO
    }
}
