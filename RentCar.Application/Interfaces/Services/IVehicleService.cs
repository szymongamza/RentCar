using RentCar.Domain.Common.Query;
using RentCar.Domain.Common.Responses;
using RentCar.Domain.Entities;

namespace RentCar.Application.Interfaces.Services;
public interface IVehicleService
{
    Task<QueryResult<Vehicle>> ListAsync(VehicleQuery query);
    Task<VehicleResponse> AddAsync(Vehicle vehicleModel);
    Task<VehicleResponse> UpdateAsync(int id, Vehicle vehicle);
    Task<VehicleResponse> DeleteAsync(int id);
}
