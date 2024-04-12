using Autoverleih_Backend.Models;
using Autoverleih_Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using urlaubsplanungstool_backend.Db.Repositories;

namespace Autoverleih_Backend.Controller;

[Route("api/[controller]")]
[ApiController]
public class CarController : ControllerBase
{
    private readonly ICarService _carService;
    private readonly IGenericRepository<Car> _genericRepository;

    public CarController(ICarService carService, IGenericRepository<Car> genericRepository)
    {
        _carService = carService;
        _genericRepository = genericRepository;
    }

    [Authorize]
    [HttpGet]
    public async Task<ActionResult<List<Car>>> GetAllCars()
    {
        return await _genericRepository.GetAll();
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Car>> CreateCar(CreateCarRequest createCarRequest)
    {
        var success = await _carService.CreateCar(createCarRequest);
        if (success != null)
        {
            return Ok(success);
        }

        return BadRequest();
    }
}