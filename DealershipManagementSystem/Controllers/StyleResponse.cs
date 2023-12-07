namespace DealershipManagementSystem.Controllers;

public class StyleResponse
{
    public string Id { get; set; }
    public string Name { get; set; }
    public List<CarResponse> Cars { get; set; }
}