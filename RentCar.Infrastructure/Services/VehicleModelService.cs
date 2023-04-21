using Microsoft.Extensions.Caching.Memory;
using RentCar.Application.Interfaces.Repositories;
using RentCar.Application.Interfaces.Services;
using RentCar.Domain.Common.Query;
using RentCar.Domain.Common.Responses;
using RentCar.Domain.Entities;
using RentCar.Domain.Enums;

namespace RentCar.Infrastructure.Services;
public class VehicleModelService : IVehicleModelService
{
    private readonly IManufacturerRepository _manufacturerRepository;
    private readonly IVehicleModelRepository _vehicleModelRepository;
    private readonly IMemoryCache _cache;
    public VehicleModelService(IVehicleModelRepository vehicleModelRepository, IMemoryCache cache, IManufacturerRepository manufacturerRepository)
    {
        _vehicleModelRepository = vehicleModelRepository;
        _cache = cache;
        _manufacturerRepository = manufacturerRepository;
    }
    public async Task<QueryResult<VehicleModel>> ListAsync(VehicleModelQuery query)
    {
        string cacheKey = GetCacheKeyForVehicleModelQuery(query);

        var vehicleModels = await _cache.GetOrCreateAsync(cacheKey, (entry) =>
        {
            entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1);
            return _vehicleModelRepository.ToListAsync(query);
        });

        return vehicleModels;
    }

    public async Task<VehicleModelResponse> AddAsync(VehicleModel vehicleModel)
    {
        try
        {
            var existingManufacturer = await _manufacturerRepository.FindByIdAsync(vehicleModel.ManufacturerId);
            if (existingManufacturer == null)
                return new VehicleModelResponse("Invalid manufacturer.");

            await _vehicleModelRepository.AddAsync(vehicleModel);

            return new VehicleModelResponse(vehicleModel);
        }
        catch (Exception ex)
        {

            return new VehicleModelResponse($"An error occurred when saving the vehicle model: {ex.Message}");
        }
    }


    public async Task<VehicleModelResponse> UpdateAsync(int id, VehicleModel vehicleModel)
    {
        var existingVehicleModel = await _vehicleModelRepository.FindByIdAsync(id);

        if (existingVehicleModel == null)
            return new VehicleModelResponse("Vehicle model not found.");

        var existingManufacturer = await _manufacturerRepository.FindByIdAsync(existingVehicleModel.ManufacturerId);
        if (existingManufacturer == null)
            return new VehicleModelResponse("Invalid manufacturer.");


        existingVehicleModel.ModelName = vehicleModel.ModelName;
        existingVehicleModel.Description = vehicleModel.Description;
        existingVehicleModel.ManufacturerId = vehicleModel.ManufacturerId;

        try
        {
            await _vehicleModelRepository.UpdateAsync(existingVehicleModel);
            return new VehicleModelResponse(existingVehicleModel);
        }
        catch (Exception ex)
        {
            return new VehicleModelResponse($"An error occurred when updating the vehicle model: {ex.Message}");
        }
    }

    public async Task<VehicleModelResponse> DeleteAsync(int id)
    {
        {
            var existingVehicleModel = await _vehicleModelRepository.FindByIdAsync(id);

            if (existingVehicleModel == null)
                return new VehicleModelResponse("Vehicle model not found.");

            try
            {
                await _vehicleModelRepository.DeleteAsync(existingVehicleModel);

                return new VehicleModelResponse(existingVehicleModel);
            }
            catch (Exception ex)
            {
                return new VehicleModelResponse($"An error occurred when deleting the vehicle model: {ex.Message}");
            }
        }
    }
    private string GetCacheKeyForVehicleModelQuery(VehicleModelQuery query)
    {
        string key = CacheKeys.VehicleModelsList.ToString();

        if (query.ManufacturerId is > 0)
        {
            key = string.Concat(key, "_", query.ManufacturerId.Value);
        }

        key = string.Concat(key, "_", query.Page, "_", query.ItemsPerPage);
        return key;
    }
}
