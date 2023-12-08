namespace DealershipManagementSystem.Controllers;

public record CarRequest(string ManufacturerId, string ModelId, string StyleId,string Year, string Kilometers,string Condition,string ColourId);