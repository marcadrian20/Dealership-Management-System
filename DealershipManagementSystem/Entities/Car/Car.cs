using DealershipManagementSystem.Repository;
using DealershipManagementSystem.Entities.Car.Colours;
using DealershipManagementSystem.Entities.Car.Styles;
using DealershipManagementSystem.Entities.Car.Models;
using DealershipManagementSystem.Entities.Car.Manufacturers;

namespace DealershipManagementSystem.Entities.Car;

public class Car:Entity
{
    //public string Id { get; private  set; }
    public Manufacturer Manufacturer { get; set; }
    public Model Model { get; set; }
    public Style Style { get; set; }
    public string Year { get; private set; }
    public string Kilometers { get; private set; }
    public string Condition { get; private set; }
    public Colour Colour { get; set; }
    private Car()
    {
    }
    
    public static async Task<Car> CreateAsync(
        ICarRepository _carRepository,
        Manufacturer manufacturer,
        Model model,
        Style style,
        string year, 
        string kilometers,
        string condition,
        Colour colour)
    {
        if (string.IsNullOrWhiteSpace(year))
            throw new Exception("Year can't be empty, please enter it");
        if (string.IsNullOrWhiteSpace(kilometers))
            throw new Exception("Kilometers can't be empty");
        if (string.IsNullOrWhiteSpace(condition))
            throw new Exception("Condition can't be empty, please enter it");
        return new Car
        {
            //Id = Guid.NewGuid().ToString(),
            Manufacturer = manufacturer,
            Model = model,
            Style = style,
            Year = year,
            Kilometers = kilometers,
            Condition = condition,
            Colour = colour
        };
    }
    public void SetYear(string year)
    {
        if (string.IsNullOrWhiteSpace(year))
            throw new Exception("Year can't be empty");
        year=year.Replace(" ", "");
        Year=year;
    }

    public void SetKilometers(string kilometers)
    {
        if (string.IsNullOrWhiteSpace(kilometers))
            throw new Exception("Kilometers can't be empty");
        Kilometers = kilometers;
    }
    public void SetCondition(string condtion)
    {
        if (string.IsNullOrWhiteSpace(condtion))
            throw new Exception("Condition can't be empty");
        Condition = condtion;
    }
}