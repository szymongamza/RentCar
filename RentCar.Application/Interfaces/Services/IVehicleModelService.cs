using RentCar.Application.Interfaces.Services.Responses;
using RentCar.Domain.Entities;

namespace RentCar.Application.Interfaces.Services;
public interface IVehicleModelService
{
    Task<IEnumerable<VehicleModel>> ListAsync();
    Task<ManufacturerResponse> AddAsync(VehicleModel vehicleModel);
    Task<ManufacturerResponse> UpdateAsync(int id, VehicleModel vehicleModel);
    Task<ManufacturerResponse> DeleteAsync(int id);
}
