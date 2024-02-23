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
    
    [HttpPost("Login")]
    public async Task<ActionResult<String>> Login(LoginRequest request)
    {
        ResultModel result = await _authService.Login(request);
        if (!result) 
        {
            return BadRequest(result.Error);
        }
        return Ok((result as DataResult<String>)?.Data);
    }
    
    [HttpPost("Register")]
    public async Task<ActionResult<UserDto>> Register(RegisterRequest request)
    {
        ResultModel resultModel = await _authService.Register(request);
        if (!resultModel)
        {
            return BadRequest(resultModel.Error);
        }

        return Ok((resultModel as DataResult<String>)!.Data);
    }   
}