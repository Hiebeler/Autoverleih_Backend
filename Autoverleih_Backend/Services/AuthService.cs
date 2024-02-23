using AutoMapper;
using Autoverleih_Backend.Db.Data;
using Autoverleih_Backend.Models;
using urlaubsplanungstool_backend.Db.Repositories;
using urlaubsplanungstool_backend.Services.Result;

namespace Autoverleih_Backend.Services;

public class AuthService: IAuthService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _automapper;
    public AuthService(IUnitOfWork unitOfWork, IMapper automapper)
    {
        _unitOfWork = unitOfWork;
        _automapper = automapper;
    }
    
    public Task<ResultModel> Login()
    {
        throw new NotImplementedException();
    }

    public async Task<ResultModel> Register(RegisterRequest register)
    {
        User newUser = new User()
        {
            Email = register.Email,
            Username = register.Username,
            Password = register.Password
        };
        User user = await _unitOfWork.Users.Add(newUser);
        _unitOfWork.Complete();
        
        return SuccessResult.WithData(_automapper.Map<UserDto>(user));
    }
}