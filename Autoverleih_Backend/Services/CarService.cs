using Autoverleih_Backend.Models;
using urlaubsplanungstool_backend.Db.Repositories;

namespace Autoverleih_Backend.Services;

public class CarService: ICarService
{
    private readonly IGenericRepository<Car> _genericRepository;
    public CarService(IGenericRepository<Car> genericRepository)
    {
        _genericRepository = genericRepository;
    }
    public async Task<Car?> CreateCar(CreateCarRequest createCarRequest)
    {
        Car newCar = new Car()
        {
            Type = createCarRequest.Type,
            Model = createCarRequest.Model,
            Seats = createCarRequest.Seats,
            CarBrand = createCarRequest.CarBrand,
            TrunkSpace = createCarRequest.TrunkSpace
        };
        var worked = await _genericRepository.Add(newCar);
        return worked;
    }
}