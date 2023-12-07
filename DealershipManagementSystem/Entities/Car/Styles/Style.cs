namespace DealershipManagementSystem.Entities.Car.Styles;

public class Style:Entity
{
    public string Name { get; set; }
    public List<Car> Cars { get; set; }
    public Style(string name)
    {
        Name = name;
    }
}