using JWT;
using Microsoft.AspNetCore.Mvc;
using Exceptions;
using Models;
using Services;
using System.Text;
using System.Text.Json;

namespace Controllers;
[ApiController]
public class UsersController : Controller
{
    private readonly byte[] JwtKey = Encoding.UTF8.GetBytes("example_key_lol_dont_use_in_prod");
    private IJwtDecoder decoder;
    private IJwtEncoder encoder;
    private IJwtValidator validator;
    private IUserRepository repo;

    public UsersController(IJwtDecoder decoder, IJwtEncoder encoder, IJwtValidator validator, IUserRepository repo)
    {
        this.decoder = decoder;
        this.encoder = encoder;
        this.validator = validator;
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
            var jwt = encoder.Encode(new { sub = data.Username }, JwtKey);
            return Json(jwt);
        }
        else
        {
            throw new LoginFailedException();
        }
    }
    [HttpGet("/whoami")]
    public IActionResult Whoami()
    {
        var values = Request.Headers["Authorization"];
        if (!values.Any())
        {
            throw new UnauthorizedException();
        }
        var jwt = values.First() ?? throw new UnauthorizedException();
        jwt = jwt.Split(":").Last()?.Split(" ").Last() ?? throw new UnauthorizedException();
        var userDataJson = decoder.Decode(jwt);
        return Json(userDataJson);
    }
}