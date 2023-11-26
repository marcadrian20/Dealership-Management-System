using Microsoft.EntityFrameworkCore;
using DealershipManagementSystem.Entities;
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
}