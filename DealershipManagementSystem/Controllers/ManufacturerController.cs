using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DealershipManagementSystem.Controllers;
using DealershipManagementSystem.Entities.Car;
using DealershipManagementSystem.Entities.Car.Manufacturers;
using DealershipManagementSystem.Entities.Car.Models;
using DealershipManagementSystem.Repository;
namespace DealershipManagementSystem.Controllers;

[Route("manufacturers")]
[ApiController]
public class ManufacturerController:ControllerBase
{
    private readonly AppDbContext _context;

    public ManufacturerController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ManufacturerResponse>>> GetManufacturer()
    {
        var manufacturer = await _context.Manufacturers
            .Include(s=>s.Cars)
            .ToListAsync();
        return Ok(manufacturer.Select(c => new ManufacturerResponse
        {
            Id=c.Id ,
            Name = c.ManufacturerName,
            Cars = c.Cars.Select(r => new CarResponse
            {
                Id = r.Id,
                ManufacturerId = c.Id
            }).ToList()
        }));
    }

    [HttpPost]
    public async Task<ActionResult<Manufacturer>> CreateManufacturer([FromBody] ManufacturerRequest manufacturerRequest)
    {
        var manufacturer = new Manufacturer(manufacturerRequest.ManufacturerName);
        _context.Add(manufacturer);
        await _context.SaveChangesAsync();
        return Ok(manufacturer);
    }
}