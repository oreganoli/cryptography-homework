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
    private IAuthenticationSvc authSvc;
    private IUserLogic logic;

    public UsersController(IAuthenticationSvc authSvc, IUserLogic logic)
    {
        this.authSvc = authSvc;
        this.logic = logic;
    }

    /// <summary>
    /// Return a view of all users.
    /// </summary>
    /// <returns>A JSON array of registered users.</returns>
    [HttpGet("/users")]
    public IActionResult GetAll()
    {
        return Json(logic.ListUsers());
    }
    /// <summary>
    /// Register a new user.
    /// </summary>
    /// <param name="data">A <c>RegisterData</c> object, ie. a username and password.</param>
    /// <returns>201 OK on success.</returns>
    [HttpPost("/register")]
    public IActionResult Register(RegisterData data)
    {
        logic.Register(data.Username, data.Password, "ex2");
        var result = Json($"Successfully created the new user {data.Username}!");
        result.StatusCode = StatusCodes.Status201Created;
        return result;
    }
    /// <summary>
    /// Register a new user in legacy mode, using the Ex.1 password hashing method.
    /// ☠️ DEPRECATED! ☠️
    /// </summary>
    /// <param name="data">A <c>RegisterData</c> object, ie. a username and password.</param>
    /// <returns>201 OK on success.</returns>
    [HttpPost("/register_legacy")]
    public IActionResult RegisterLegacy(RegisterData data)
    {
        logic.Register(data.Username, data.Password, "ex1");
        var result = Json($"Successfully created the new user {data.Username}!");
        result.StatusCode = StatusCodes.Status201Created;
        return result;
    }
    [HttpPost("/login")]
    public IActionResult Login(LoginData data)
    {
        if (logic.Validate(data.Username, data.Password))
        {
            var jwt = authSvc.GetJwtForUsername(data.Username);
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
        var username = authSvc.GetUsernameFromJwt(HttpContext);
        return Json($"You are logged in as {username}");
    }
    [HttpDelete("/deleteAccount")]
    public IActionResult DeleteAccount()
    {
        var username = authSvc.GetUsernameFromJwt(HttpContext);
        logic.DeleteAccount(username);
        return new NoContentResult();
    }
    [HttpPut("/password")]
    public IActionResult ChangePassword(ChangePasswordData data)
    {
        var username = authSvc.GetUsernameFromJwt(HttpContext);
        logic.ChangePassword(username, data.OldPassword, data.NewPassword);
        return new NoContentResult();
    }
}