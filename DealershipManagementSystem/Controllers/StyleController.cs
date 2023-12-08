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
            .Include(s=>s.Cars)
            .ToListAsync();
        return Ok(styles.Select(c => new StyleResponse
        {
            Id=c.Id ,
            Name = c.StyleName,
            Cars = c.Cars.Select(r => new CarResponse
            {
                Id = r.Id,
                StyleId = c.Id
            }).ToList()
        }));
    }

    [HttpPost]
    public async Task<ActionResult<Style>> CreateStyle([FromBody] StyleRequest styleRequest)
    {
        var style = new Style(styleRequest.StyleName);
        _context.Add(style);
        await _context.SaveChangesAsync();
        return Ok(style);
    }
}