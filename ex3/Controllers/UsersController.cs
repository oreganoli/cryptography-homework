using Microsoft.AspNetCore.Mvc;
namespace Controllers;
public class UsersController : Controller
{
    /// <summary>
    /// Return a view of all users.
    /// </summary>
    /// <returns>A JSON array of registered users.</returns>
    [HttpGet("/users")]
    public IActionResult GetAll()
    {
        // empty data for now
        return Json(new object[] { });
    }
}