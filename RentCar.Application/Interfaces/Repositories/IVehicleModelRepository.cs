using RentCar.Domain.Common.Query;
using RentCar.Domain.Entities;

namespace RentCar.Application.Interfaces.Repositories;
public interface IVehicleModelRepository : IGenericRepository<VehicleModel>
{
    Task<QueryResult<VehicleModel>> ToListAsync(VehicleModelQuery query);
}
