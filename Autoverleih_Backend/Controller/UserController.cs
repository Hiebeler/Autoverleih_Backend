using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Autoverleih_Backend.Controller;
[Route("api/[controller]")]
[ApiController]
public class UserController: ControllerBase
{
    private readonly UserManager<IdentityUser> _userManager;

    public UserController(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }

    [Authorize]
    [HttpGet]
    public async Task<ActionResult<IdentityUser>> GetUser()
    {
        ClaimsPrincipal currentUser = User;
        var currentUserName = currentUser.FindFirst(ClaimTypes.Name).Value;
        IdentityUser user = await _userManager.FindByNameAsync(currentUserName);
        return Ok(user);
    }
}