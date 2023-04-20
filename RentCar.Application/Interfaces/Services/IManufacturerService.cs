using RentCar.Domain.Common.Responses;
using RentCar.Domain.Entities;

namespace RentCar.Application.Interfaces.Services;

public interface IManufacturerService
{
    Task<IEnumerable<Manufacturer>> ListAsync();
    Task<ManufacturerResponse> AddAsync(Manufacturer manufacturer);
    Task<ManufacturerResponse> UpdateAsync(int id, Manufacturer manufacturer);
    Task<ManufacturerResponse> DeleteAsync(int id);
}