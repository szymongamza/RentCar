using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentCar.Application.Interfaces.Repositories;
using RentCar.Domain.Entities;
using RentCar.Infrastructure.Data;

namespace RentCar.Infrastructure.Repositories;
public class VehicleModelRepository : GenericRepository<VehicleModel>, IVehicleModelRepository
{
    public VehicleModelRepository(RentCarDbContext dbContext) : base(dbContext)
    {
    }
}
