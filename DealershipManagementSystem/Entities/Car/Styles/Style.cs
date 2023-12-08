using DealershipManagementSystem.Entities.Car;
namespace DealershipManagementSystem.Entities.Car.Styles;

public class Style:Entity
{
    public string StyleName { get; set; }
    public List<Car> Cars { get; set; }
    public Style(string styleName)
    {
        StyleName = styleName;
    }
}