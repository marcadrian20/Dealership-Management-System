namespace DealershipManagementSystem.Entities.Car.Models;

public class Model:Entity
{
    public string ModelName { get; set; }
    public List<Car> Cars { get; set; }
    public Model(string modelName)
    {
        ModelName=modelName;
    }
}