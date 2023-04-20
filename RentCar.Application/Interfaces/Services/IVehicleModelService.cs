using RentCar.Domain.Common.Query;
using RentCar.Domain.Common.Responses;
using RentCar.Domain.Entities;

namespace RentCar.Application.Interfaces.Services;
public interface IVehicleModelService
{
    Task<QueryResult<VehicleModel>> ListAsync(VehicleModelQuery query);
    Task<VehicleModelResponse> AddAsync(VehicleModel vehicleModel);
    Task<VehicleModelResponse> UpdateAsync(int id, VehicleModel vehicleModel);
    Task<VehicleModelResponse> DeleteAsync(int id);
}
