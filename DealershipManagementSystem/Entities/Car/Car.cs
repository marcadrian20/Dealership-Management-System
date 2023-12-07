using DealershipManagementSystem.Repository;
using DealershipManagementSystem.Entities.Car.Colours;
using DealershipManagementSystem.Entities.Car.Styles;

namespace DealershipManagementSystem.Entities.Car;

public class Car:Entity
{
    //public string Id { get; private  set; }
    public string Manufacturer { get; private set; }
    public string Model { get; private set; }
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
        string manufacturer,
        string model,
        Style style,
        string year, 
        string kilometers,
        string condition,
        Colour colour)
    {
        if (string.IsNullOrWhiteSpace(manufacturer))
            throw new Exception("Car make can't be empty");
        if (string.IsNullOrWhiteSpace(model))
            throw new Exception("Model can't be empty, please enter it");
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

    public void SetManufacturer(string manufacturer)
    {
        if (string.IsNullOrWhiteSpace(manufacturer))
            throw new Exception("Manufacturer name can't be empty");
        manufacturer = manufacturer.Replace(" ", "");
        Manufacturer = manufacturer;
    }

    public void SetModel(string model)
    {
        if (string.IsNullOrWhiteSpace(model))
            throw new Exception("Model can't be empty");
        Model = model;
    }
    public void SetYear(string year)
    {
        if (string.IsNullOrWhiteSpace(year))
            throw new Exception("Year can't be empty");
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