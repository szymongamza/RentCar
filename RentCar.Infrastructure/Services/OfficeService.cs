
using Microsoft.Extensions.Caching.Memory;
using RentCar.Application.Interfaces.Repositories;
using RentCar.Application.Interfaces.Services;
using RentCar.Domain.Common.Responses;
using RentCar.Domain.Entities;
using RentCar.Domain.Enums;
using RentCar.Infrastructure.Repositories;

namespace RentCar.Infrastructure.Services;
public class OfficeService : IOfficeService
{
    private readonly IOfficeRepository _officeRepository;
    private readonly IMemoryCache _cache;
    public OfficeService(IOfficeRepository officeRepository, IMemoryCache cache)
    {
        _officeRepository = officeRepository;
        _cache = cache;
    }

    public async Task<IEnumerable<Office>> ListAsync()
    {
        var offices = await _cache.GetOrCreateAsync(CacheKeys.OfficesList, (entry) =>
        {
            entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(2);
            return _officeRepository.ToListAsync();
        });

        return offices;
    }

    public async Task<OfficeResponse> AddAsync(Office office)
    {
        try
        {
            await _officeRepository.AddAsync(office);

            return new OfficeResponse(office);
        }
        catch (Exception ex)
        {
            return new OfficeResponse($"An error occurred when saving the office: {ex.Message}");
        }
    }

    public async Task<OfficeResponse> UpdateAsync(int id, Office office)
    {
        var existingOffice = await _officeRepository.FindByIdAsync(id);

        if (existingOffice == null)
            return new OfficeResponse("Office not found.");

        existingOffice.OfficeName = office.OfficeName;
        existingOffice.PhoneNumber = office.PhoneNumber;
        existingOffice.Address = office.Address;
        existingOffice.TimeOpen = office.TimeOpen;
        existingOffice.TimeClose = office.TimeClose;
        existingOffice.Description = office.Description;
        existingOffice.ImagePath = office.ImagePath;

        try
        {

            return new OfficeResponse(existingOffice);
        }
        catch (Exception ex)
        {
            return new OfficeResponse($"An error occurred when updating the office: {ex.Message}");
        }
    }

    public async Task<OfficeResponse> DeleteAsync(int id)
    {
        var existingOffice = await _officeRepository.FindByIdAsync(id);

        if (existingOffice == null)
            return new OfficeResponse("Office not found.");

        try
        {
            await _officeRepository.DeleteAsync(existingOffice);

            return new OfficeResponse(existingOffice);
        }
        catch (Exception ex)
        {
            return new OfficeResponse($"An error occurred when deleting the office: {ex.Message}");
        }
    }
}
