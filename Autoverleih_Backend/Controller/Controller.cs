using System.Security.Claims;
using Autoverleih_Backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Autoverleih_Backend.Controller;

[Route("api/Auth")]
[ApiController]
public class Controller: ControllerBase
{
    [Authorize]
    [HttpGet]
    public ActionResult<String> GetTodoItems()
    {
        var userShort = User.FindFirstValue(ClaimTypes.NameIdentifier);
        return Ok(userShort);
    }    
}