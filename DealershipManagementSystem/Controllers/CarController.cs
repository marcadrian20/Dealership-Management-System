using System.Data.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DealershipManagementSystem.Entities;
using DealershipManagementSystem.Entities.Car;
using DealershipManagementSystem.Repository;
namespace DealershipManagementSystem.Controllers;

[Route("cars")]
[ApiController]
public class CarController : ControllerBase
{
    /*private static readonly List<Car> CarCatalogue = new()
    {
        Car.Create("Mazda", "RX7", "FD3S","2002","53344KM","Used","Red"),
        Car.Create("Subaru", "XV", "Basic","2023","0KM","New","Green"),
        Car.Create("Lancia", "Delta", "SuperSport","1989","200022KM","Used","Blue")
    };*///replaced by:
    private readonly AppDbContext _dbContext; //
    private readonly ICarRepository _carRepository;
    public CarController(AppDbContext dbContext,ICarRepository carRepository)//
    {
        _dbContext = dbContext;
        _carRepository = carRepository;
    }
    [HttpGet(Name = "GetAllCars")]
    public async Task<ActionResult> GetCars()
    {
        var cars =await _dbContext.Set<Car>().ToListAsync();
        return Ok(cars);
    }

    [HttpGet( "{Id}")]
    public async Task<ActionResult> GetCar(string Id)
    {
        //var car = CarCatalogue.FirstOrDefault(s => s.Id == Id);
        //replaced by:
        var car = await _dbContext.Cars
            .Where(cars => cars.Id == Id)
            .OrderBy(car => car.Manufacturer)
            .FirstOrDefaultAsync();
        if (car is null)
            return NotFound($"Car with id: {Id} does not exist");

        return Ok(car);
    }
    
    [HttpPost]
    public async Task<ActionResult> CreateCar([FromBody] CarRequest carRequest)
    {
        var colour = await _dbContext.Colours
            .FirstOrDefaultAsync(c => c.Id == carRequest.ColourId);
        var style = await _dbContext.Styles
            .FirstOrDefaultAsync(s => s.name == carRequest.StyleId);
        if (colour is null)
            return NotFound($"Colour with id: {carRequest.ColourId} wasnt found");
        Car car = null;
        try
        {
            car = await Car.CreateAsync(
                _carRepository,
                carRequest.Manufacturer,
                carRequest.Model,
                style,
                carRequest.Year,
                carRequest.Kilometers,
                carRequest.Condition,
                colour);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }

        //CarCatalogue.Add(car); Replaced by:
        _dbContext.Add(car);
        _dbContext.SaveChangesAsync();
        return Ok(new CarResponse
        {
            Id = car.Id,
            ColourId = colour.Id
        });
    }

    [HttpDelete("{Id}")]
    public async Task<ActionResult> RemoveCar(string Id)
    {
        //var car = CarCatalogue.FirstOrDefault(s => s.Id == Id);
        var car =await _dbContext.Cars.FirstOrDefaultAsync(s => s.Id == Id);
        if (car is null)
            return NotFound($"Car with id: {Id} does not exist");

        //CarCatalogue.Remove(car);
        _dbContext.Remove(car);
        _dbContext.SaveChangesAsync();
        return Ok($"Car with id: {Id} was removed");
    }
    [HttpPut("{Id}")]
    public async Task<ActionResult> UpdateCar(string Id, [FromBody]CarRequest carRequest)
    {
        //var car = CarCatalogue.FirstOrDefault(s => s.Id == Id);
        var car =await _dbContext.Cars.FirstOrDefaultAsync(s => s.Id == Id);
        if (car is null)
            return NotFound($"Car with id: {Id} does not exist");

        try
        {
            car.SetManufacturer(carRequest.Manufacturer);
            car.SetModel(carRequest.Model);
            car.SetYear(carRequest.Year);
            car.SetKilometers(carRequest.Kilometers);
            car.SetCondition(carRequest.Condition);
            //car.SetColour(carRequest.Colour);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }

        _dbContext.SaveChangesAsync();
        return Ok(car);
    }
    

}