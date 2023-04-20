using Microsoft.Extensions.Caching.Memory;
using RentCar.Application.Intefaces.Repositories;
using RentCar.Application.Intefaces.Services;
using RentCar.Application.Intefaces.Services.Responses;
using RentCar.Domain.Entities;
using RentCar.Domain.Enums;

namespace RentCar.Application.Services
{
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
            var existingCategory = await _manufacturerRepository.FindByIdAsync(id);

            if (existingCategory == null)
                return new ManufacturerResponse("Manufacturer not found.");

            try
            {
                await _manufacturerRepository.DeleteAsync(existingCategory);

                return new ManufacturerResponse(existingCategory);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new ManufacturerResponse($"An error occurred when deleting the manufacturer: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Manufacturer>> ListAsync()
        {
            var manufacturers = await _cache.GetOrCreateAsync(CacheKeys.ManufacturersList, (entry) => {
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
                // Do some logging stuff
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
                // Do some logging stuff
                return new ManufacturerResponse($"An error occurred when updating the manufacturer: {ex.Message}");
            }
        }

    }
}
