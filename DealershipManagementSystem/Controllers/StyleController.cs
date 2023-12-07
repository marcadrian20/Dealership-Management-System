using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DealershipManagementSystem.Controllers;
using DealershipManagementSystem.Entities.Car;
using DealershipManagementSystem.Entities.Car.Styles;
using DealershipManagementSystem.Repository;

namespace DealershipManagementSystem.Controllers;

[Route("styles")]
[ApiController]
public class StylesController : ControllerBase
{
    private readonly AppDbContext _context;

    public StylesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<StyleResponse>>> GetStyle()
    {
        var styles = await _context.Styles
            .Include(s=>s.)
            .ToListAsync();
        return Ok(styles.Select(c => new ColourResponse
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