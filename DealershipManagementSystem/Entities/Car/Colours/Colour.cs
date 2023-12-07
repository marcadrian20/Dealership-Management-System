namespace DealershipManagementSystem.Entities.Car.Colours;
public class Colour:Entity
{
    public string Color { get; set; }
    public List<Car> Cars { get; set; }
    public Colour(string color)
    { 
        Color=color;
    }
}