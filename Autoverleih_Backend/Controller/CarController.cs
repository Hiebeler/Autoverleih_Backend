using Autoverleih_Backend.Models;
using Autoverleih_Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Autoverleih_Backend.Controller;

[Route("api/[controller]")]
[ApiController]
public class CarController : ControllerBase
{
    private readonly ICarService _carService;

    public CarController(ICarService carService)
    {
        _carService = carService;
    }

    [Authorize]
    [HttpGet]
    public ActionResult<List<String>> GetAllCars()
    {
        return new List<String>() { "Volvo", "Audi", "BMW" };
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