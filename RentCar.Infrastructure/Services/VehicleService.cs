
using RentCar.Application.Interfaces.Services;
using RentCar.Domain.Common.Query;
using RentCar.Domain.Common.Responses;
using RentCar.Domain.Entities;

namespace RentCar.Infrastructure.Services;
public class VehicleService : IVehicleService
{
    public async Task<QueryResult<Vehicle>> ListAsync(VehicleQuery query)
    {
        throw new NotImplementedException();
    }

    public async Task<VehicleResponse> AddAsync(Vehicle vehicleModel)
    {
        throw new NotImplementedException();
    }

    public async Task<VehicleResponse> UpdateAsync(int id, Vehicle vehicle)
    {
        throw new NotImplementedException();
    }

    public async Task<VehicleResponse> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}
