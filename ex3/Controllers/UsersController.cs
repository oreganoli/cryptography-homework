using Microsoft.AspNetCore.Mvc;
using Exceptions;
using Models;
using Services;

namespace Controllers;
[ApiController]
public class UsersController : Controller
{
    private IUserRepository repo;

    public UsersController(IUserRepository repo)
    {
        this.repo = repo;
    }

    /// <summary>
    /// Return a view of all users.
    /// </summary>
    /// <returns>A JSON array of registered users.</returns>
    [HttpGet("/users")]
    public IActionResult GetAll()
    {
        return Json(repo.GetAllUsers());
    }
    /// <summary>
    /// Register a new user.
    /// </summary>
    /// <param name="data">A <c>RegisterData</c> object, ie. a username and password.</param>
    /// <returns>201 OK on success.</returns>
    [HttpPost("/register")]
    public IActionResult Register(RegisterData data)
    {
        repo.RegisterUser(data);
        var result = Json($"Successfully created the new user {data.Username}!");
        result.StatusCode = StatusCodes.Status201Created;
        return result;
    }
    [HttpPost("/login")]
    public IActionResult Login(LoginData data)
    {
        if (repo.Authenticate(data.Username, data.Password))
        {
            // TODO return a JWT
            return new OkResult();
        }
        else
        {
            throw new LoginFailedException();
        }
    }
}