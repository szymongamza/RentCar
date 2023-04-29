
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.Extensions.Caching.Memory;
using RentCar.Application.Interfaces.Repositories;
using RentCar.Application.Interfaces.Services;
using RentCar.Domain.Common.Query;
using RentCar.Domain.Common.Responses;
using RentCar.Domain.Entities;
using RentCar.Domain.Enums;
using RentCar.Infrastructure.Repositories;

namespace RentCar.Infrastructure.Services;
public class VehicleService : IVehicleService
{
    private readonly IVehicleRepository _vehicleRepository;
    private readonly IVehicleModelRepository _vehicleModelRepository;
    private readonly IMemoryCache _cache;

    public VehicleService(IVehicleRepository vehicleRepository, IVehicleModelRepository vehicleModelRepository, IMemoryCache cache )
    {
        _vehicleModelRepository = vehicleModelRepository;
        _vehicleRepository = vehicleRepository;
        _cache = cache;
    }

    
    public async Task<QueryResult<Vehicle>> ListAsync(VehicleQuery query)
    {
        if (query.StartDateTime is not null && query.EndDateTime is not null)
            return await _vehicleRepository.ToListAsync(query);

        string cacheKey = GetCacheKeyForVehicleQuery(query);
        var vehicles = await _cache.GetOrCreateAsync(cacheKey, (entry) =>
        {
            entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(2);
            return _vehicleRepository.ToListAsync(query);
        });

        return vehicles;
    }

    public async Task<VehicleResponse> AddAsync(Vehicle vehicle)
    {
        try
        {
            var existingVehicleModel = await _vehicleModelRepository.FindByIdAsync(vehicle.VehicleModelId);
            if (existingVehicleModel == null)
                return new VehicleResponse("Invalid vehicle model.");
            if (vehicle.ImagePath is null || vehicle.ImagePath.Length == 0)
            {
                vehicle.ImagePath = existingVehicleModel.ImagePath;
            }

            await _vehicleRepository.AddAsync(vehicle);

            return new VehicleResponse(vehicle);
        }
        catch (Exception ex)
        {

            return new VehicleResponse($"An error occurred when saving the vehicle: {ex.Message}");
        }
    }

    public async Task<VehicleResponse> UpdateAsync(int id, Vehicle vehicle)
    {
        var existingVehicle = await _vehicleRepository.FindByIdAsync(id);

        if (existingVehicle == null)
            return new VehicleResponse("Vehicle not found.");

        var existingVehicleModel = await _vehicleModelRepository.FindByIdAsync(existingVehicle.VehicleModelId);
        if (existingVehicleModel == null)
            return new VehicleResponse("Invalid vehicle model.");


        existingVehicle.Year = vehicle.Year;
        existingVehicle.Description = vehicle.Description;
        existingVehicle.VehicleModelId = vehicle.VehicleModelId;
        existingVehicle.Status = vehicle.Status;
        existingVehicle.RegistrationNumber = vehicle.RegistrationNumber;
        existingVehicle.DailyPrice = vehicle.DailyPrice;
        existingVehicle.ImagePath = vehicle.ImagePath;
        existingVehicle.Description = vehicle.Description;

        try
        {
            await _vehicleRepository.UpdateAsync(existingVehicle);
            return new VehicleResponse(existingVehicle);
        }
        catch (Exception ex)
        {
            return new VehicleResponse($"An error occurred when updating the vehicle: {ex.Message}");
        }
    }

    public async Task<VehicleResponse> DeleteAsync(int id)
    {
        {
            var existingVehicle = await _vehicleRepository.FindByIdAsync(id);

            if (existingVehicle == null)
                return new VehicleResponse("Vehicle not found.");

            try
            {
                await _vehicleRepository.DeleteAsync(existingVehicle);

                return new VehicleResponse(existingVehicle);
            }
            catch (Exception ex)
            {
                return new VehicleResponse($"An error occurred when deleting the vehicle: {ex.Message}");
            }
        }
    }

    private string GetCacheKeyForVehicleQuery(VehicleQuery query)
    {
        string key = CacheKeys.VehicleList.ToString();

        if (query.VehicleModelId is > 0)
        {
            key = string.Concat(key, "_", "vmid:" , query.VehicleModelId.Value);
        }

        if (query.Status is not null)
        {
            key = string.Concat(key, "_", "status:", query.Status);
        }

        key = string.Concat(key, "_", query.Page, "_", query.ItemsPerPage);
        return key;
    }
}
