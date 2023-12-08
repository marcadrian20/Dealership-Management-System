namespace DealershipManagementSystem.Controllers;

public class ManufacturerResponse
{
    public string Id { get; set; }
    public string Name { get; set; }
    public List<CarResponse> Cars { get; set; }
}