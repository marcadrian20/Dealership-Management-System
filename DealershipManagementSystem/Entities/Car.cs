using Microsoft.AspNetCore.Http.HttpResults;

namespace DealershipManagementSystem.Entities;

public class Car:Entity
{
    //public string Id { get; private  set; }
    public string Manufacturer { get; private set; }
    public string Model { get; private set; }
    public string Trim { get; private set; }
    public string Year { get; private set; }
    public string Kilometers { get; private set; }
    public string Condition { get; private set; }
    public string Colour { get; private set; }
    private Car()
    {
    }
    
    public static Car Create(string manufacturer, string model, string trim, string year, string kilometers,string condition,string colour)
    {
        if (string.IsNullOrWhiteSpace(manufacturer))
            throw new Exception("Car make can't be empty");
        if (string.IsNullOrWhiteSpace(model))
            throw new Exception("Model can't be empty, please enter it");
        if (string.IsNullOrWhiteSpace(trim))
            throw new Exception("Trim can't be empty, please enter it");
        if (string.IsNullOrWhiteSpace(year))
            throw new Exception("Year can't be empty, please enter it");
        if (string.IsNullOrWhiteSpace(kilometers))
            throw new Exception("Kilometers can't be empty");
        if (string.IsNullOrWhiteSpace(condition))
            throw new Exception("Condition can't be empty, please enter it");
        if (string.IsNullOrWhiteSpace(colour))
            throw new Exception("Colour can't be empty, please enter it");
        return new Car
        {
            //Id = Guid.NewGuid().ToString(),
            Manufacturer = manufacturer,
            Model = model,
            Trim = trim,
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
    public void SetTrim(string trim)
    {
        if (string.IsNullOrWhiteSpace(trim))
            throw new Exception("Trim can't be empty");
        Trim = trim;
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
    public void SetColour(string colour)
    {
        if (string.IsNullOrWhiteSpace(colour))
            throw new Exception("Condition can't be empty");
        Colour = colour;
    }
}