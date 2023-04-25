using Microsoft.EntityFrameworkCore;
using RentCar.Domain.Entities;

namespace RentCar.Infrastructure.Data;
public class RentCarDbContext : DbContext
{
    public DbSet<Manufacturer> Manufacturers { get; set; }
    public DbSet<VehicleModel> VehicleModels { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<Office> Offices { get; set; }
    public DbSet<Booking> Bookings { get; set; }


    public RentCarDbContext(DbContextOptions<RentCarDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
