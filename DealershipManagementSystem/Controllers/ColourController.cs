using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DealershipManagementSystem.Controllers;
using DealershipManagementSystem.Entities.Car;
using DealershipManagementSystem.Entities.Car.Colours;
using DealershipManagementSystem.Repository;
namespace DealershipManagementSystem.Controllers;

[Route("colours")]
[ApiController]
public class ColourController:ControllerBase
{
    private readonly AppDbContext _context;

    public ColourController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ColourResponse>>> GetColour()
    {
        var colours = await _context.Colours
            .Include(c => c.Cars)
            .ToListAsync();
        return Ok(colours.Select(c => new ColourResponse
        {
            Id = c.Id,
            Name = c.Color,
            Cars = c.Cars.Select(r => new CarResponse
            {
                Id = r.Id,
                ColourId = c.Color
            }).ToList()
        }));
    }

    [HttpPost]
    public async Task<ActionResult<Colour>> CreateColour([FromBody] ColourRequest colourRequest)
    {
        var colour = new Colour(colourRequest.name);
        _context.Add(colour);
        await _context.SaveChangesAsync();
        return Ok(colour);
    }
}