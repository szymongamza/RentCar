using RentCar.Application.Interfaces.Repositories;
using RentCar.Domain.Entities;
using RentCar.Infrastructure.Data;

namespace RentCar.Infrastructure.Repositories;
public class VehicleRepository : GenericRepository<Vehicle>, IVehicleRepository
{
    public VehicleRepository(RentCarDbContext dbContext) : base(dbContext)
    {
    }
}
