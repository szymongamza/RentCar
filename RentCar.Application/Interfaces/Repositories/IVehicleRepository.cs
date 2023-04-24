using RentCar.Domain.Common.Query;
using RentCar.Domain.Entities;

namespace RentCar.Application.Interfaces.Repositories;
public interface IVehicleRepository : IGenericRepository<Vehicle>
{
    Task<QueryResult<Vehicle>> ToListAsync(VehicleQuery query);
}
