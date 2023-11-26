using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DealershipManagementSystem.Entities;
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
    public CarController(AppDbContext dbContext)//
    {
        _dbContext = dbContext;
    }
    [HttpGet(Name = "GetAllCars")]
    public ActionResult GetCars()
    {
        var cars = _dbContext.Set<Car>().ToList();
        return Ok(cars);
    }

    [HttpGet( "{Id}")]
    public ActionResult GetCar(string Id)
    {
        //var car = CarCatalogue.FirstOrDefault(s => s.Id == Id);
        //replaced by:
        var car = _dbContext.Cars
            .Where(cars => cars.Id == Id)
            .OrderBy(car => car.Manufacturer)
            .FirstOrDefault();
        if (car is null)
            return NotFound($"Car with id: {Id} does not exist");

        return Ok(car);
    }
    
    [HttpPost]
    public ActionResult CreateCar([FromBody] CarRequest carRequest)
    {
        Car car = null;
        try
        {
            car = Car.Create(carRequest.Manufacturer, carRequest.Model, carRequest.Trim,carRequest.Year,carRequest.Kilometers,carRequest.Condition,carRequest.Colour);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }

        //CarCatalogue.Add(car); Replaced by:
        _dbContext.Add(car);
        _dbContext.SaveChanges();
        return Ok(car);
    }

    [HttpDelete("{Id}")]
    public ActionResult RemoveCar(string Id)
    {
        //var car = CarCatalogue.FirstOrDefault(s => s.Id == Id);
        var car = _dbContext.Cars.FirstOrDefault(s => s.Id == Id);
        if (car is null)
            return NotFound($"Car with id: {Id} does not exist");

        //CarCatalogue.Remove(car);
        _dbContext.Remove(car);
        _dbContext.SaveChanges();
        return Ok($"Car with id: {Id} was removed");
    }
    [HttpPut("{Id}")]
    public ActionResult UpdateCar(string Id, [FromBody]CarRequest carRequest)
    {
        //var car = CarCatalogue.FirstOrDefault(s => s.Id == Id);
        var car = _dbContext.Cars.FirstOrDefault(s => s.Id == Id);
        if (car is null)
            return NotFound($"Car with id: {Id} does not exist");

        try
        {
            car.SetManufacturer(carRequest.Manufacturer);
            car.SetModel(carRequest.Model);
            car.SetTrim(carRequest.Trim);
            car.SetYear(carRequest.Year);
            car.SetKilometers(carRequest.Kilometers);
            car.SetCondition(carRequest.Condition);
            car.SetColour(carRequest.Colour);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        

        return Ok(car);
    }
    

}