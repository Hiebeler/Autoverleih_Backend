using AutoMapper;
using Autoverleih_Backend.Db.Data;
using Autoverleih_Backend.Models;
using urlaubsplanungstool_backend.Common;
using urlaubsplanungstool_backend.Db.Repositories;
using urlaubsplanungstool_backend.Services.Result;

namespace Autoverleih_Backend.Services;

public class AuthService : IAuthService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _automapper;
    private readonly IPasswordService _passwordService;
    private readonly IJwtService _jwtService;

    public AuthService(IUnitOfWork unitOfWork, IMapper automapper, IPasswordService passwordService,
        IJwtService jwtService)
    {
        _unitOfWork = unitOfWork;
        _automapper = automapper;
        _passwordService = passwordService;
        _jwtService = jwtService;
    }

    public async Task<ResultModel> Login(LoginRequest loginRequest)
    {
        List<User> usersFromDatabase = await _unitOfWork.Users.Find(u => u.Username == loginRequest.Username);
        User userFromDatabase = usersFromDatabase!.First();
        if (userFromDatabase == null) return new FailResult("Wrong UserShort");

        var passwordVerified = _passwordService.VerifyPassword(
            loginRequest.Password, userFromDatabase.Password);
        if (!passwordVerified) return new FailResult("Wrong Password");

        String jwtToken = _jwtService.GenerateJwtToken(userFromDatabase);
        return SuccessResult.WithData(jwtToken);
    }

    public async Task<ResultModel> Register(RegisterRequest register)
    {
        User newUser = new User()
        {
            Email = register.Email,
            Username = register.Username,
            Password = _passwordService.HashPassword(register.Password)
        };
        User user = await _unitOfWork.Users.Add(newUser);
        _unitOfWork.Complete();

        string jwt = _jwtService.GenerateJwtToken(user);

        return SuccessResult.WithData(jwt);
    }
}