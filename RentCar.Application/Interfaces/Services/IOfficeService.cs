
using RentCar.Domain.Common.Responses;
using RentCar.Domain.Entities;

namespace RentCar.Application.Interfaces.Services;
public interface IOfficeService
{
    Task<IEnumerable<Office>> ListAsync();
    Task<OfficeResponse> AddAsync(Office office);
    Task<OfficeResponse> UpdateAsync(int id, Office office);
    Task<OfficeResponse> DeleteAsync(int id);
}
