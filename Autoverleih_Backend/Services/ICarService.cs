using Autoverleih_Backend.Models;

namespace Autoverleih_Backend.Services;

public interface ICarService
{
    public Task<Car?> CreateCar(CreateCarRequest createCarRequest);
}