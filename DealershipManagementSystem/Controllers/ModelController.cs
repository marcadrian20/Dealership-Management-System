using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DealershipManagementSystem.Controllers;
using DealershipManagementSystem.Entities.Car;
using DealershipManagementSystem.Entities.Car.Models;
using DealershipManagementSystem.Repository;
using Microsoft.AspNetCore.Http.HttpResults;

namespace DealershipManagementSystem.Controllers;

[Route("models")]
[ApiController]
public class ModelController:ControllerBase
{
    private readonly AppDbContext _context;

    public ModelController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ModelResponse>>> GetModel()
    {
        var models = await _context.Models
            .Include(s=>s.Cars)
            .ToListAsync();
        return Ok(models.Select(c => new ModelResponse
        {
            Id=c.Id ,
            Name = c.ModelName,
            Cars = c.Cars.Select(r => new CarResponse
            {
                Id = r.Id,
                ModelId = c.Id
            }).ToList()
        }));
    }

    [HttpPost]
    public async Task<ActionResult<Model>> CreateModel([FromBody] ModelRequest modelRequest)
    {
        var model = new Model(modelRequest.ModelName);
        _context.Add(model);
        await _context.SaveChangesAsync();
        return Ok(model);
    }
}