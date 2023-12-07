using DealershipManagementSystem.Controllers;
using Microsoft.EntityFrameworkCore;
using DealershipManagementSystem.Entities;
using DealershipManagementSystem.Entities.Car;
using DealershipManagementSystem.Entities.Car.Colours;

namespace DealershipManagementSystem.Repository;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
    public DbSet<Car> Cars { get; set; }
    public DbSet<Colour> Colours { get; set; }
    public DbSet<Style> Styles { get; set; }
}