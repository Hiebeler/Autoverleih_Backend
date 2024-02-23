using Microsoft.AspNetCore.Mvc;

namespace Autoverleih_Backend.Controller;

[Route("api/Auth")]
[ApiController]
public class Controller: ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<String>> GetTodoItems()
    {
        return "WORKS";
    }    
}