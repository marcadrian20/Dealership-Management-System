using DealershipManagementSystem.Entities.Car;
using Microsoft.EntityFrameworkCore;
namespace DealershipManagementSystem.Repository;

public class CarRepository:ICarRepository
{
    private readonly AppDbContext _context;

    public CarRepository(AppDbContext context)
    {
        _context = context;
    }
    //public async Task<>
}