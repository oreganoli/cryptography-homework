using Exceptions;
using Models;

namespace Services;

public class UserLogic : IUserLogic
{
    private IUserRepository repo;
    private IHasher hasher;

    public UserLogic(IUserRepository repo, IHasher hasher)
    {
        this.repo = repo;
        this.hasher = hasher;
    }

    public void ChangePassword(string username, string oldPassword, string newPassword)
    {
        if (!repo.UserExists(username))
        {
            throw new NoSuchUserException(username);
        }
        if (!Validate(username, oldPassword))
        {
            throw new WrongOldPasswordException();
        }
        var user = repo.ReadUser(username) ?? throw new NoSuchUserException(username);
        var salt = hasher.ProduceSalt();
        var hash = hasher.Hash(newPassword, salt);
        user.Password = hash;
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
        var salt = hasher.ProduceSalt();
        var hash = hasher.Hash(password, salt);
        var userData = new User
        {
            Algorithm = hashMethod,
            Password = hash,
            Salt = salt,
            Username = username
        };
        repo.UpsertUser(userData);
    }

    public bool Validate(string username, string password)
    {
        var user = repo.ReadUser(username);
        if (user == null)
        {
            return false;
        }
        return hasher.Verify(password, user.Salt, user.Password);
    }
}
