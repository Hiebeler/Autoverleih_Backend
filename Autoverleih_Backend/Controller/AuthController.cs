using Autoverleih_Backend.Models;
using Autoverleih_Backend.Services;
using Microsoft.AspNetCore.Mvc;
using urlaubsplanungstool_backend.Services.Result;

namespace Autoverleih_Backend.Controller;

[Route("api/[controller]")]
[ApiController]
public class AuthController: ControllerBase
{
    private readonly IAuthService _authService;
    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }
    
    [HttpGet("Login")]
    public async Task<ActionResult<String>> Login()
    {
        return "WORKS";
    }
    
    [HttpPost("Register")]
    public async Task<ActionResult<UserDto>> Register(RegisterRequest request)
    {
        ResultModel resultModel = await _authService.Register(request);
        if (!resultModel)
        {
            return BadRequest(resultModel.Error);
        }

        return Ok((resultModel as DataResult<UserDto>)!.Data);
    }   
}