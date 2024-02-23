using Autoverleih_Backend.Models;
using urlaubsplanungstool_backend.Services.Result;

namespace Autoverleih_Backend.Services;

public interface IAuthService
{
    public Task<ResultModel> Login();
    public Task<ResultModel> Register(RegisterRequest register);
}