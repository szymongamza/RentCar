using Microsoft.Extensions.Caching.Memory;
using RentCar.Application.Interfaces.Repositories;
using RentCar.Application.Interfaces.Services;
using RentCar.Domain.Common.Responses;
using RentCar.Domain.Entities;
using RentCar.Domain.Enums;

namespace RentCar.Infrastructure.Services;

public class ManufacturerService : IManufacturerService
{
    private readonly IManufacturerRepository _manufacturerRepository;
    private readonly IMemoryCache _cache;
    public ManufacturerService(IManufacturerRepository manufacturerRepository, IMemoryCache cache)
    {
        _manufacturerRepository = manufacturerRepository;
        _cache = cache;

    }

    public async Task<ManufacturerResponse> DeleteAsync(int id)
    {
        var existingManufacturer = await _manufacturerRepository.FindByIdAsync(id);

        if (existingManufacturer == null)
            return new ManufacturerResponse("Manufacturer not found.");

        try
        {
            await _manufacturerRepository.DeleteAsync(existingManufacturer);

            return new ManufacturerResponse(existingManufacturer);
        }
        catch (Exception ex)
        {
            return new ManufacturerResponse($"An error occurred when deleting the manufacturer: {ex.Message}");
        }
    }

    public async Task<IEnumerable<Manufacturer>> ListAsync()
    {
        var manufacturers = await _cache.GetOrCreateAsync(CacheKeys.ManufacturersList, (entry) =>
        {
            entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1);
            return _manufacturerRepository.ToListAsync();
        });

        return manufacturers;
    }

    public async Task<ManufacturerResponse> AddAsync(Manufacturer manufacturer)
    {
        try
        {
            await _manufacturerRepository.AddAsync(manufacturer);

            return new ManufacturerResponse(manufacturer);
        }
        catch (Exception ex)
        {
            return new ManufacturerResponse($"An error occurred when saving the manufacturer: {ex.Message}");
        }
    }

    public async Task<ManufacturerResponse> UpdateAsync(int id, Manufacturer manufacturer)
    {
        var existingManufacturer = await _manufacturerRepository.FindByIdAsync(id);

        if (existingManufacturer == null)
            return new ManufacturerResponse("Manufacturer not found.");

        existingManufacturer.ManufacturerName = manufacturer.ManufacturerName;

        try
        {

            return new ManufacturerResponse(existingManufacturer);
        }
        catch (Exception ex)
        {
            return new ManufacturerResponse($"An error occurred when updating the manufacturer: {ex.Message}");
        }
    }

}