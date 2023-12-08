namespace DealershipManagementSystem.Entities.Car.Manufacturers;

public class Manufacturer:Entity
{
    public string ManufacturerName { get; set; }
    public List<Car> Cars { get; set; }
    public Manufacturer(string manufacturerName)
    {
        ManufacturerName = manufacturerName;
    }
}