namespace DealershipManagementSystem.Entities.Car.Models;

public class Model:Entity
{
    public string Name { get; set; }
    public List<Car> Cars { get; set; }
    public Model(string name)
    {
        Name = name;
    }
}